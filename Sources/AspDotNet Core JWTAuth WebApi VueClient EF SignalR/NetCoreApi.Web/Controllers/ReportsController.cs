using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mime;
using FastReport;
using FastReport.Export.Image;
using FastReport.Export.Html;
using FastReport.Utils;
using FastReport.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ReportsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // Creates the report as HTML result
        [HttpGet]
        public IActionResult Get()
        {
            //var webRootPath = _hostingEnvironment.WebRootPath;
            var ReportPath = (@"Reports\Master-Detail.frx");

            if (!System.IO.File.Exists(ReportPath))
            {
                return NotFound();
            }

            // Create a stream for the report
            using (var stream = new MemoryStream())
            {
                try
                {
                    Config.WebMode = true;

                    var Mime = "text/htlm";

                    using (Report report = new Report())
                    {
                        var dataSet = new DataSet();
                        dataSet.ReadXml(@"Data\nwind.xml");

                        report.Load(ReportPath);
                        report.RegisterData(dataSet, "NorthWind");
                        report.Prepare();

                        var html = new HTMLExport
                        {
                            SinglePage = true,
                            Navigator = false,
                            EmbedPictures = true
                        };

                        report.Export(html, stream);
                    }

                    // Get the name of the resulting report file with the necessary extension 
                    //var file = string.Concat(Path.GetFileNameWithoutExtension(reportPath), ".html");
                    // ... and Download the report file 
                    //return File(stream.ToArray(), Mime, file); // attachment

                    //... or open the report in the browser
                    return File(stream.ToArray(), Mime);
                    
                }
                // Handle exceptions
                catch (Exception ex)
                {
                    return new NoContentResult();
                }
                finally
                {
                    stream.Dispose();
                }
            }
        }

        // -- Shows Report in Browser Preview
        [HttpGet("[action]")]
        public IActionResult ShowReport()
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"Data\nwind.xml");

            var wr = new WebReport
            {
                Width = "1000",
                Height = "1000"
            };

            wr.Report.Load(@"Reports\Master-Detail.frx");
            wr.Report.RegisterData(dataSet, "NorthWind");

            ViewBag.WebReport = wr;

            return View();
        }
    }
}
