using System.Collections.Generic;

namespace SquashLeague.Models
{
    public interface ISquashRepository
    {
        IEnumerable<Trip> GetAllTrips();
    }
}