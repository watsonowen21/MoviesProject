using Movies.Interfaces.Repositories;
using Movies.Interfaces.Services;
using Movies.Models;
using Movies.Models.Dtos;

namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            List<MovieDto> movieList = new List<MovieDto>();

            var movies = await _movieRepository.GetMovies();

            if (movies.Count() == 0) { return movieList; }

            foreach (var movie in movies)
            {
                var movieDto = new MovieDto()
                {
                    Id = movie.Id,
                    Name = movie.Name
                };

                movieList.Add(movieDto);
            }

            return movieList;
        }

        public async Task<MovieDto?> GetMovie(int id)
        {
            var movie = await _movieRepository.GetMovie(id);

            if (movie == null) { return null; }

            var movieDto = new MovieDto()
            {
                Id = movie.Id,
                Name = movie.Name
            };

            return movieDto;
        }

        public async Task<PostMovieResponseDto> AddMovie(PostMovieRequestDto request)
        {
            var movie = new Movie()
            {
                Name= request.Name,
                ReleaseDate = request.ReleaseDate
            };

            var movieDto = await _movieRepository.AddMovie(movie);

            return new PostMovieResponseDto()
            {
                Id = movieDto.Id
            };
        }

        public async Task<Movie?> UpdateMovie(int id, UpdateMovieDto request)
        {
            var existingMovie = await _movieRepository.GetMovie(id);

            if (existingMovie == null)
            {
                return null;
            }

            existingMovie.Name = request.Name;
            existingMovie.ReleaseDate = request.ReleaseDate;

            return await _movieRepository.UpdateMovie(existingMovie);
        }

        public async Task<Movie?> DeleteMovie(int id)
        {
            var movie = await _movieRepository.GetMovie(id);

            if (movie == null) { return null; }

            return await _movieRepository.DeleteMovie(movie);
        }
    }
}