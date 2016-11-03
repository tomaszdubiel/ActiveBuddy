using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SquashLeague.Models;
using SquashLeague.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquashLeague.Controllers.Api
{
    [Route("api/trips")]
    public class TripsController : Controller
    {
       
        private ISquashRepository _repo;

        public TripsController(ISquashRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repo.GetAllTrips();
                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
            }
            catch(Exception ex)
            {
                return BadRequest($"Error from GET: {ex}");
            }
            
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]TripViewModel theTrip)
        {
            if(ModelState.IsValid)
            {
                var newTrip = Mapper.Map<Trip>(theTrip);

                return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
            }
            return BadRequest("Bad request");
        }
    }
}
