using Movies.Models;
using Movies.Models.Dtos;

namespace Movies.Interfaces.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetGenres();
        Task<GenreDto?> GetGenre(int id);
        Task<PostGenreResponseDto> AddGenre(PostGenreRequestDto request);
        Task<Genre?> UpdateGenre(int id, UpdateGenreDto request);
        Task<Genre?> DeleteGenre(int id);
    }
}
