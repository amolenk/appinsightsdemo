using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceDemo.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

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

        private readonly Random _randomizer;
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudTableClient _tableClient;
        private readonly CloudTable _table;

        public RideManager(string storageConnectionString)
        {
            _randomizer = new Random();
            _storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();
            _table = _tableClient.GetTableReference("Bookings");

            _table.CreateIfNotExists();
        }
  
        public RideConfirmation BookRide(RideRequest request)
        {
            var vehicle = GetVehicle();
            var eta = GetEta();

            // For testing purposes, wait a little while to simulate some busy work.
            // TODO Remove this before going to production. We'll definitely not forget this!
            Task.Delay(_randomizer.Next(0, 1500)).GetAwaiter().GetResult();

            SaveBooking(request, vehicle.LicenseNumber);

            return new RideConfirmation(vehicle, eta);
        }

        private Vehicle GetVehicle()
        {
            var make = ModelsByMake.Keys.ElementAt(_randomizer.Next(0, ModelsByMake.Count));
            var model = ModelsByMake[make][_randomizer.Next(0, ModelsByMake[make].Count)];
            var licenseNumber = "GOTMILK";

            return new Vehicle(licenseNumber, make, model);
        }

        private int GetEta()
        {
            return _randomizer.Next(1, 12);
        }

        private void SaveBooking(RideRequest request, string vehicleLicenseNumber)
        {
            var entity = new DynamicTableEntity(
                request.CustomerId,
                DateTime.UtcNow.Ticks.ToString(),
                "*",
                new Dictionary<string, EntityProperty>
                {
                    { "StartLatitude", EntityProperty.GeneratePropertyForDouble(request.StartLocation.Latitude) },
                    { "StartLongitude", EntityProperty.GeneratePropertyForDouble(request.StartLocation.Longitude) },
                    { "EndLatitude", EntityProperty.GeneratePropertyForDouble(request.EndLocation.Latitude) },
                    { "EndLongitude", EntityProperty.GeneratePropertyForDouble(request.EndLocation.Longitude) },
                    { "Vehicle", EntityProperty.GeneratePropertyForString(vehicleLicenseNumber) }
                });

            _table.Execute(TableOperation.Insert(entity));
        }
    }
}
