using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<SongController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> Get()
        {
            try
            {
                var songs = await _context.Songs.ToListAsync();
                return Ok(songs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            try
            {
                var song = await _context.Songs.SingleOrDefaultAsync(s => s.Id == id);
                if (song == null)
                {
                    return NotFound();
                }
                return Ok(song);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<SongController>
        [HttpPost]
        public async Task<ActionResult<Song>> AddSong(Song song)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Songs.Add(song);
                await _context.SaveChangesAsync();

                return Ok(song);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Song>> EditSong(int id, Song song)
        {
            try
            {
                var _song = await _context.Songs.SingleOrDefaultAsync(s => s.Id == id);

                if (_song == null)
                {
                    return NotFound();
                }

                _song.Title = song.Title;
                _song.FilePath = song.FilePath;
                _song.UserId = song.UserId;
                _song.GenreId = song.GenreId;

                await _context.SaveChangesAsync();

                return Ok(_song);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> DeleteSong(int id)
        {
            try
            {
                var song = await _context.Songs.SingleOrDefaultAsync(s => s.Id == id);
                if (song == null)
                {
                    return NotFound();
                }

                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();

                return Ok(song);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
