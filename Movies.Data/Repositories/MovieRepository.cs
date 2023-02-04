using Movies.Data.Context;
using Movies.Interfaces.Repositories;
using Movies.Models;

namespace Movies.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesContext context) : base(context)
        {
        }
    }
}
