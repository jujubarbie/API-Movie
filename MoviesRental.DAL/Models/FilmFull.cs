using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Models
{
    public class FilmFull : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public int RentalDuration { get; set; }
        public decimal RentalPrice { get; set; }
        public int Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public int RatingId { get; set; }
        public string Rating { get; set; }

        public FilmFull(string title, string description, int releaseYear, int languageId, string language, int rentalDuration, decimal rentalPrice, int length, decimal replacementCost, int ratingId, string rating)
        {
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            LanguageId = languageId;
            Language = language;
            RentalDuration = rentalDuration;
            RentalPrice = rentalPrice;
            Length = length;
            ReplacementCost = replacementCost;
            RatingId = ratingId;
            Rating = rating;
        }

        internal FilmFull(int id, string title, string description, int releaseYear, int languageId, string language, int rentalDuration, decimal rentalPrice, int length, decimal replacementCost, int ratingId, string rating)
            : this (title, description, releaseYear, languageId, language, rentalDuration, rentalPrice, length, replacementCost, ratingId, rating)
        {
            Id = id;
        }

        public FilmFull()
        {
        }
    }
}
