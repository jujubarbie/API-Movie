using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Models
{
    public class Film : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public int RentalDuration { get; set; }
        public decimal RentalPrice { get; set; }
        public int Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public int RatingId { get; set; }

        public Film(string title, string description, int releaseYear, int languageId, int rentalDuration, decimal rentalPrice, int length, decimal replacementCost, int ratingId)
        {
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            LanguageId = languageId;
            RentalDuration = rentalDuration;
            RentalPrice = rentalPrice;
            Length = length;
            ReplacementCost = replacementCost;
            RatingId = ratingId;
        }

        internal Film(int id, string title, string description, int releaseYear, int languageId, int rentalDuration, decimal rentalPrice, int length, decimal replacementCost, int ratingId)
            : this (title, description, releaseYear, languageId, rentalDuration, rentalPrice, length, replacementCost, ratingId)
        {
            Id = id;
        }

        public Film()
        {
        }
    }
}
        