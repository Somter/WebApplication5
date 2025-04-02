using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Get()
        {
            try
            {
                var genres = await _context.Genre.ToListAsync();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            try
            {
                var genre = await _context.Genre.SingleOrDefaultAsync(g => g.Id == id);
                if (genre == null)
                {
                    return NotFound();
                }
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<GenreController>
        [HttpPost]
        public async Task<ActionResult<Genre>> AddGenre(Genre genre)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Genre.Add(genre);
                await _context.SaveChangesAsync();

                return Ok(genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Genre>> EditGenre(int id, Genre genre)
        {
            try
            {
                var _genre = await _context.Genre.SingleOrDefaultAsync(g => g.Id == id);

                if (_genre == null)
                {
                    return NotFound();
                }

                _genre.Name = genre.Name;

                await _context.SaveChangesAsync();

                return Ok(_genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var genre = await _context.Genre.SingleOrDefaultAsync(g => g.Id == id);
                if (genre == null)
                {
                    return NotFound();
                }

                _context.Genre.Remove(genre);
                await _context.SaveChangesAsync();

                return Ok(genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
