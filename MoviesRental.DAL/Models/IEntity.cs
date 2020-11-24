using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
