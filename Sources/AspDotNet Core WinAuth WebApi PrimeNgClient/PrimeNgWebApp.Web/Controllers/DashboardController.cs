using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using $ext_safeprojectname$.Core.Data.ViewModels;
using $ext_safeprojectname$.Core.Interface;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        private readonly ILogger<DashboardController> _logger;


        public DashboardController(IDashboardService dashboardService, ILogger<DashboardController> logger)
        {
            _dashboardService = dashboardService;
            _logger = logger;
        }


        [HttpGet("top3tracks")]
        [Produces(typeof(List<TopTrackViewModel>))]
        public async Task<IActionResult> GetTop3Tracks()
        {
            try
            {
                return Ok(await _dashboardService.GetTop3TracksAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpGet("statistics")]
        [Produces(typeof(StatisticsViewModel))]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                return Ok(await _dashboardService.GetStatisticsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }
    }
}
