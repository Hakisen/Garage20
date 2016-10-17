using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public TypeOfVehicle TypeOfVehicle { get; set; }
        public string RegNr { get; set; }
        public string colour { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NrOfWheels { get; set; }
        public DateTime TimeIn { get; set; }
    }
    public enum TypeOfVehicle
    {
        Car,
        Truck,
        Motorcycle,
        Housewagon,
        Trailer
    }
}