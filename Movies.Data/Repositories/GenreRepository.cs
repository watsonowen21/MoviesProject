using Microsoft.EntityFrameworkCore;
using Movies.Data.Context;
using Movies.Interfaces.Repositories;
using Movies.Models;

namespace Movies.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MoviesContext _context;

        public GenreRepository(MoviesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetGenre(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<Genre> AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> UpdateGenre(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> DeleteGenre(Genre genre)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
    }
}
