using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class TypeOfVehicle
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }

        //public int VehicleId { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }

    }
}