using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceDemo.Controllers
{
    [Route("api/[controller]")]
    public class RequestsController : Controller
    {
        private readonly RideManager _rideManager;

        public RequestsController(RideManager rideManager)
        {
            _rideManager = rideManager;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/requests
        [HttpPost]
        public IActionResult Post([FromBody]RideRequest request)
        {
            if (string.IsNullOrEmpty(request.CustomerId))
            {
                throw new ArgumentException("Customer id is missing.", "request");
            }

            var confirmation = _rideManager.BookRide(request);

            return Ok(confirmation);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
