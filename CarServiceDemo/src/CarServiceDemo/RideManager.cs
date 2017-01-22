using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceDemo.Model;

namespace CarServiceDemo
{
    public class RideManager
    {
        private static Dictionary<string, List<string>> ModelsByMake = new Dictionary<string, List<string>>
        {
            {
                "Audi",
                new List<string> { "A6", "Q7" }
            },
            {
                "Toyota",
                new List<string> { "Prius" }
            }
        };

        private static Random Randomizer = new Random();

        public static RideConfirmation BookRide(RideRequest request)
        {
            var vehicle = GetVehicle();
            var eta = GetEta();

            return new RideConfirmation(vehicle, eta);
        }

        private static Vehicle GetVehicle()
        {
            var make = ModelsByMake.Keys.ElementAt(Randomizer.Next(0, ModelsByMake.Count));
            var model = ModelsByMake[make][Randomizer.Next(0, ModelsByMake[make].Count)];
            var licenseNumber = "GOTMILK";

            return new Vehicle(licenseNumber, make, model);
        }

        private static int GetEta()
        {
            return Randomizer.Next(1, 12);
        }
    }
}
