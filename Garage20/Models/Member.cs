﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public int VehicleId { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }

    }
}