using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Interfaces.Repositories;
using Movies.Models;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await _genreRepository.GetAll();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _genreRepository.GetById(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostMovie(Genre genre)
        {
            _genreRepository.Add(genre);
            await _genreRepository.SaveChanges();

            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }


        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _genreRepository.Update(genre);

            try
            {
                await _genreRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _genreRepository.GetById(id);

            if (genre == null)
            {
                return NotFound();
            }

            _genreRepository.Delete(genre);
            await _genreRepository.SaveChanges();

            return NoContent();
        }

        private bool GenreExists(int id)
        {
            var genre = _genreRepository.GetById(id);

            if (genre == null)
            { return false; }

            return true;
        }
    }
}
