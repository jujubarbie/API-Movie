using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Models
{
    public class ActorInitials
    {
        public char InitialFirstName { get; set; }

        public ActorInitials(char initialFirstName)
        {
            InitialFirstName = initialFirstName;
        }

        public ActorInitials()
        {
        }
    }
}
