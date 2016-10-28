﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string MemberName { get; set; }

        //public int VehicleId { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }

    }
}