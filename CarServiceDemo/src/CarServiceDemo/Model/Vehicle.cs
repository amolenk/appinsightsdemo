using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceDemo.Model
{
    public class Vehicle
    {
        public Vehicle(string licenseNumber, string make, string model)
        {
            LicenseNumber = licenseNumber;
            Make = make;
            Model = model;
        }

        /// <summary>
        /// Getst the vehicle identification number.
        /// </summary>
        public string LicenseNumber { get; private set; }

        /// <summary>
        /// Gets the vehicle make.
        /// </summary>
        public string Make { get; private set; }

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public string Model { get; private set; }
    }
}
