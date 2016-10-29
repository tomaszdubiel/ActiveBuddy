using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquashLeague.Models
{
    public class SquashRepository : ISquashRepository
    {
        private SquashContext _context;
        private ILogger<SquashRepository> _logger;

        public SquashRepository(SquashContext context,
            ILogger<SquashRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting All Trips from the DB");
            return _context.Trips.ToList();
        }
    }
}
