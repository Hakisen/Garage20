using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class TypeOfVehicle
    {
        public int Id { get; set; }
        [Required]
        public string VehicleType { get; set; }
                
        public virtual List<Vehicle> Vehicles { get; set; }

    }
}