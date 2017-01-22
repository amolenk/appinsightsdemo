using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceDemo.Model
{
    public class RideRequest
    {
        public RideRequest(Guid customerId, Location startLocation, Location endLocation)
        {
            CustomerId = customerId;
            StartLocation = startLocation;
            EndLocation = endLocation;
        }

        /// <summary>
        /// Gets the unique customer id.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the pick-up location.
        /// </summary>
        public Location StartLocation { get; private set; }

        /// <summary>
        /// Gets the drop-off location.
        /// </summary>
        public Location EndLocation { get; private set; }
    }
}
