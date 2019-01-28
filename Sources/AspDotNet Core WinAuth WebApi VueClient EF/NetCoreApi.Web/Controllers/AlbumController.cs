using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using $ext_safeprojectname$.Core.Data.Manager;
using $ext_safeprojectname$.Core.Data.ViewModels;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        private readonly IDataManager _dataManager;

        public AlbumController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        [Produces(typeof(List<AlbumViewModel>))]
        public async Task<IActionResult> Get(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _dataManager.GetAllAlbumAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(AlbumViewModel))]
        public async Task<IActionResult> Get(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                var album = await _dataManager.GetAlbumByIdAsync(id, ct);
                if (album == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(album);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("artist/{id}")]
        [Produces(typeof(List<AlbumViewModel>))]
        public async Task<IActionResult> GetByArtistId(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                var artist = await _dataManager.GetArtistByIdAsync(id, ct);
                if ( artist == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(await _dataManager.GetAlbumByArtistIdAsync(id, ct));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(AlbumViewModel))]
        public async Task<IActionResult> Post([FromBody] AlbumViewModel input,
            CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, await _dataManager.AddAlbumAsync(input, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        [Produces(typeof(AlbumViewModel))]
        public async Task<IActionResult> Put(int id, [FromBody] AlbumViewModel input,
            CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (await _dataManager.GetAlbumByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                var errors = JsonConvert.SerializeObject(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));
                Debug.WriteLine(errors);

                if (await _dataManager.UpdateAlbumAsync(input, ct))
                {
                    return Ok(input);
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(void))]
        public async Task<ActionResult> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (await _dataManager.GetAlbumByIdAsync(id, ct) == null)
                {
                    return NotFound();
                }

                if (await _dataManager.DeleteAlbumAsync(id, ct))
                {
                    return Ok();
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}