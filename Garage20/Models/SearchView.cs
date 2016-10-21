using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class SearchView
    {
        //public int Id { get; set; }
        public string typeOfVehicle { get; set; }
        public string regNr { get; set; }
        public string colour { get; set; }
        public string brand { get; set; }
        public string model { get; set; }              
        public string nrOfWheels { get; set; }
    }
}