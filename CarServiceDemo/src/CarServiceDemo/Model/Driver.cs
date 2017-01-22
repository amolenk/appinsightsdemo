using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceDemo.Model
{
    public class Driver
    {
        public Driver(Guid driverId, string firstName, string lastName)
        {
            DriverId = driverId;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Gets the unique driver id.
        /// </summary>
        public Guid DriverId { get; private set; }

        /// <summary>
        /// Gets the driver's first name.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the driver's last name.
        /// </summary>
        public string LastName { get; private set; }
    }
}
