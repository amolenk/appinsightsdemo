using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceDemo.Model
{
    public class Location
    {
        public Location(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Gets the degrees latitude.
        /// </summary>
        public float Latitude { get; private set; }

        /// <summary>
        /// Gets the degrees longitude.
        /// </summary>
        public float Longitude { get; private set; }
    }
}
