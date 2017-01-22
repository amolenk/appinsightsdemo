using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceDemo.Model
{
    public class RideConfirmation
    {
        public RideConfirmation(Vehicle vehicle, int eta)
        {
            Vehicle = vehicle;
            Eta = eta;
        }

        /// <summary>
        /// Gets the vehicle details.
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets the estimated time of vehicle arrival in minutes.
        /// </summary>
        public int Eta { get; set; }
    }
}
