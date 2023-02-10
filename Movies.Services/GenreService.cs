using Movies.Interfaces.Repositories;
using Movies.Interfaces.Services;
using Movies.Models;
using Movies.Models.Dtos;

namespace Movies.Services
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            List<GenreDto> genreList = new List<GenreDto>();

            var genres = await _genreRepository.GetGenres();

            if (genres.Count() == 0) { return genreList; }

            foreach (var genre in genres)
            {
                var genreDto = new GenreDto()
                {
                    Id = genre.Id,
                    Name = genre.Name
                };

                genreList.Add(genreDto);
            }

            return genreList;
        }

        public async Task<GenreDto?> GetGenre(int id)
        {
            var genre = await _genreRepository.GetGenre(id);

            if (genre == null) { return null; }

            var genreDto = new GenreDto()
            {
                Id = genre.Id,
                Name = genre.Name
            };

            return genreDto;
        }

        public async Task<PostGenreResponseDto> AddGenre(PostGenreRequestDto request)
        {
            var genre = new Genre()
            {
                Name= request.Name
            };

            var genreDto = await _genreRepository.AddGenre(genre);

            return new PostGenreResponseDto()
            {
                Id = genreDto.Id
            };
        }

        public async Task<Genre?> UpdateGenre(int id, UpdateGenreDto request)
        {
            var existingGenre = await _genreRepository.GetGenre(id);

            if (existingGenre == null)
            {
                return null;
            }

            existingGenre.Name = request.Name;

            return await _genreRepository.UpdateGenre(existingGenre);
        }

        public async Task<Genre?> DeleteGenre(int id)
        {
            var genre = await _genreRepository.GetGenre(id);

            if (genre == null) { return null; }

            return await _genreRepository.DeleteGenre(genre);
        }
    }
}