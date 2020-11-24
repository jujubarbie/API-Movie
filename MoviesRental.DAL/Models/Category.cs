using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Models
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }
        public string name { get; set; }

        public Category(string name)
        {
            this.name = name;
        }

        internal Category(int id, string name)
            : this (name)
        {
            Id = id;
        }

        public Category()
        {
        }
    }
}
