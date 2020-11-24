using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Models
{
    public class Actor : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Actor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        internal Actor(int id, string firstName, string lastName)
            : this(firstName, lastName)
        {
            Id = id;
        }

        public Actor()
        {
        }
    }
}
