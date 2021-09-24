using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MobileX
{
    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<string, Vehicle> vehicles;
        //private Dictionary<string, List<Vehicle>> vehiclesByBrand;
        private Dictionary<string, Dictionary<string, Vehicle>> sellers;

        public VehicleRepository()
        {
            this.vehicles = new Dictionary<string, Vehicle>();
            //this.vehiclesByBrand = new Dictionary<string, List<Vehicle>>();
            this.sellers = new Dictionary<string, Dictionary<string, Vehicle>>();
        }

        public int Count => this.vehicles.Count;

        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            if (!this.sellers.ContainsKey(sellerName))
            {
                this.sellers.Add(sellerName, new Dictionary<string, Vehicle>());
            }

            if (!this.sellers[sellerName].ContainsKey(vehicle.Id))
            {
                this.sellers[sellerName].Add(vehicle.Id, vehicle);
                this.vehicles.Add(vehicle.Id, vehicle);
                //if (!this.vehiclesByBrand.ContainsKey(vehicle.Brand))
                //{
                //    this.vehiclesByBrand.Add(vehicle.Brand, new Dictionary<string, Vehicle>());
                //}

                //this.vehiclesByBrand[vehicle.Brand].Add(vehicle.Id, vehicle);
            }
        }

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!this.sellers.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            var vehicleList = this.sellers[sellerName]
                .Values
                .OrderBy(x => x.Price)
                .ToList();

            if (vehicleList.Count() == 0)
            {
                throw new ArgumentException();
            }

            return vehicleList.FirstOrDefault();
        }

        public bool Contains(Vehicle vehicle)
        {
            return this.vehicles.ContainsKey(vehicle.Id);
        }

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            var byBrand = this.vehicles
                .Values
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Price)
                .ToList();

            if (byBrand.Count() == 0)
            {
                throw new ArgumentException();
            }

            var result = new Dictionary<string, List<Vehicle>>();

            foreach (var vehicle in byBrand)
            {
                if (!result.ContainsKey(vehicle.Brand))
                {
                    result.Add(vehicle.Brand, new List<Vehicle>());
                }

                result[vehicle.Brand].Add(vehicle);
            }

            return result;
        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()    
        {
            var result = new List<Vehicle>();

            foreach (var kvp in this.sellers.OrderBy(x => x.Key))
            {
                var orderedVehicles = kvp.Value.
                    Select(x => x.Value)
                    .ToList();

                result.AddRange(orderedVehicles);
            }

            return result
                .OrderByDescending(x => x.Horsepower)
                .ThenBy(x => x.Price)
                .ToList();
        }

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
        {
            var result = new List<Vehicle>();

            foreach (var keyword in keywords)
            {
                var vehiclesKeyword = this.vehicles
                    .Values
                    .Where(x => x.Brand == keyword
                        || x.Model == keyword
                        || x.Location == keyword
                        || x.Color == keyword)
                    .ToList();

                result.AddRange(vehiclesKeyword);
            }

            result = result
                    .OrderByDescending(x => x.IsVIP)
                    .ThenBy(x => x.Price)
                    .ToList();

            return result;
        }

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!this.sellers.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            var result = this.sellers[sellerName].Values.ToList();

            return result;
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
        {
            var result = this.vehicles
                .Values
                .Where(x => x.Price >= lowerBound && x.Price <= upperBound)
                .OrderByDescending(x => x.Horsepower)
                .ToList();

            if (result.Count() == 0)
            {
                return new List<Vehicle>();
            }

            return result;
        }

        public void RemoveVehicle(string vehicleId)
        {
            if (!this.vehicles.ContainsKey(vehicleId))
            {
                throw new ArgumentException();
            }

            vehicles.Remove(vehicleId);

            foreach (var kvp in this.sellers.Values)
            {
                kvp.Remove(vehicleId);
            }

            //this.sellers = this.sellers
            //    .Where(x => !x.Value.ContainsKey(vehicleId))
            //    .ToDictionary(x => x.Key, y => y.Value);

            //this.vehiclesByBrand = this.vehiclesByBrand
            //    .Where(x => !x.Value.ContainsKey(vehicleId))
            //    .ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
