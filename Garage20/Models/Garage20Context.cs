﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Garage20Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Garage20Context() : base("name=Garage20Context")
        {
        }

        public System.Data.Entity.DbSet<Garage20.Models.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<Garage20.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<Garage20.Models.TypeOfVehicle> TypeOfVehicles { get; set; }
    }
}
