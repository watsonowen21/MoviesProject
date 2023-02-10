using Movies.Models;
using Movies.Models.Dtos;

namespace Movies.Interfaces.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMovies();
        Task<MovieDto?> GetMovie(int id);
        Task<PostMovieResponseDto> AddMovie(PostMovieRequestDto request);
        Task<Movie?> UpdateMovie(int id, UpdateMovieDto request);
        Task<Movie?> DeleteMovie(int id);
    }
}
