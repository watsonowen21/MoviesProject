using System;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int? SecondGenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
