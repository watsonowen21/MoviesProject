using Microsoft.AspNetCore.Mvc;
using Movies.Interfaces.Services;
using Movies.Models;
using Movies.Models.Dtos;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService= movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            return await _movieService.GetMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<PostMovieResponseDto>> PostMovie(PostMovieRequestDto request)
        {
            var movie = await _movieService.AddMovie(request);
            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }


        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, [FromBody] UpdateMovieDto request)
        {
            var updatedMovie = await _movieService.UpdateMovie(id, request);

            if (updatedMovie == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.DeleteMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
