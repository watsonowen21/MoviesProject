using Movies.Models;

namespace Movies.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<Genre?> GetGenre(int id);
        Task<Genre> AddGenre(Genre genre);
        Task<Genre> UpdateGenre(Genre genre);
        Task<Genre> DeleteGenre(Genre genre);
    }
}
