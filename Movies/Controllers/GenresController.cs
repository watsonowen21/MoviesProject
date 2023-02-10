using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Interfaces.Repositories;
using Movies.Interfaces.Services;
using Movies.Models;
using Movies.Models.Dtos;
using Movies.Services;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            return await _genreService.GetGenres();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            var genre = await _genreService.GetGenre(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostGenreResponseDto>> PostGenre(PostGenreRequestDto request)
        {
            var genre = await _genreService.AddGenre(request);
            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }


        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, [FromBody] UpdateGenreDto request)
        {
            var updatedGenre = await _genreService.UpdateGenre(id, request);

            if (updatedGenre == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _genreService.DeleteGenre(id);

            if (genre == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
