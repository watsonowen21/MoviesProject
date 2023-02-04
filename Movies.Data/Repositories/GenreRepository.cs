using Movies.Data.Context;
using Movies.Interfaces.Repositories;
using Movies.Models;

namespace Movies.Data.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MoviesContext context) : base(context)
        {
        }
    }
}
