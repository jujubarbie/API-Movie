using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Models
{
    public class FilmShort : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }

        public FilmShort(string title, int releaseYear)
        {
            Title = title;
            ReleaseYear = releaseYear;
        }

        internal FilmShort(int id, string title, int releaseYear)
            : this (title, releaseYear)
        {
            Id = id;
        }

        public FilmShort()
        {
        }
    }
}
