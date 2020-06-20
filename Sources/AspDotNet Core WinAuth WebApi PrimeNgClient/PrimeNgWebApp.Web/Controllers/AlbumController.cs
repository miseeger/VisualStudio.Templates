using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using $ext_safeprojectname$.Core.Data;
using $ext_safeprojectname$.Core.Data.Converters;
using $ext_safeprojectname$.Core.Data.Entities;
using $ext_safeprojectname$.Core.Data.ViewModels;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<AlbumController> _logger;

        public AlbumController(DataContext context, ILogger<AlbumController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    AlbumConverter.ConvertList(
                        await _context.Album
                            .Include(a => a.Artist)
                            .ToListAsync()
                    )
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}")]
        [Produces(typeof(AlbumViewModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var album = await _context.Album
                    .Where(a => a.AlbumId == id)
                    .Include(a => a.Artist)
                    .Include(a => a.Tracks)
                    .FirstOrDefaultAsync();
                
                if (album == null)
                {
                    return NotFound();
                }

                return Ok(AlbumConverter.Convert(album));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }


        [HttpGet("artist/{id}")]
        [Produces(typeof(List<AlbumViewModel>))]
        public async Task<IActionResult> GetByArtistId(int id)
        {
            try
            {
                var albums = await _context.Album.Where(a => a.ArtistId == id).ToListAsync();

                if (albums == null)
                {
                    return NotFound();
                }

                return Ok(AlbumConverter.ConvertList(albums));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }


        [HttpPost]
        [Produces(typeof(AlbumViewModel))]
        public async Task<IActionResult> Post([FromBody] AlbumViewModel album)
        {
            try
            {
                if (album == null)
                    return BadRequest();

                var albumEntity = new Album
                {
                    Title = album.Title,
                    ArtistId = album.ArtistId
                };

                _context.Album.Add(albumEntity);
                await _context.SaveChangesAsync();

                album.AlbumId = albumEntity.AlbumId;

                return StatusCode(201, album);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }


        [HttpPut]
        [Produces(typeof(AlbumViewModel))]
        public async Task<IActionResult> Put([FromBody] AlbumViewModel album)
        {
            try
            {
                if (album == null)
                    return BadRequest();

                var albumEntity = await _context.Album.FirstOrDefaultAsync(a => a.AlbumId == album.AlbumId);

                if (albumEntity == null)
                {
                    return NotFound();
                }

                var errors = JsonConvert.SerializeObject(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));

                Debug.WriteLine(errors);

                albumEntity.Title = album.Title;
                albumEntity.ArtistId = album.ArtistId;

                _context.Album.Update(albumEntity);
                await _context.SaveChangesAsync();

                return Ok(album);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }


        [HttpDelete("{id}")]
        [Produces(typeof(void))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var albumEntity = await _context.Album.FirstOrDefaultAsync(a => a.AlbumId == id);
                
                if (albumEntity == null)
                {
                    return NotFound();
                }

                _context.Album.Remove(albumEntity);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }
    }
}
