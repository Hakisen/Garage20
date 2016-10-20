using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    //public class Vehicle
    //{
    //    public int Id { get; set; }
    //    public TypeOfVehicle TypeOfVehicle { get; set; }
    //    public string RegNr { get; set; }
    //    public string colour { get; set; }
    //    public string Brand { get; set; }
    //    public string Model { get; set; }
    //    public int NrOfWheels { get; set; }

    //    [Column(TypeName = "datetime2")]

    //    public DateTime TimeIn { get; set; }
    //}

    public class Vehicle
    {
        //[Key]
        public int Id { get; set; }

        public TypeOfVehicle TypeOfVehicle { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Invalid, Min 3 digits max 10 digits")]
        //[MinLength(6, ErrorMessage = " 6 digits please")]
        //[StringLength(10, MinimumLength = 3, ErrorMessage = "Invalid max 10 digits min 3 digits")]

        //Index(IsUnique = true)

        public string RegNr { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = " maximum no Of letters is 10")]
        public string colour { get; set; }

        //public string colour { get; set; }
        [MaxLength(10, ErrorMessage = " maximum no Of letters is 10")]
        public string Brand { get; set; }

        [MaxLength(10, ErrorMessage = " maximum no Of letters is 10")]
        public string Model { get; set; }

        [Range(2, 10, ErrorMessage = "0-10 please")]
        public int NrOfWheels { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeIn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeOut { get; set; }

        [Display(Name="Parking time hh:mm")]
        [DisplayFormat(DataFormatString ="{0:hh\\:mm}")]
        public TimeSpan TimeParked { get; set; }

        
        public int TimeFee { get; set; }

    }

    public enum TypeOfVehicle
    {
        Car,
        Truck,
        Motorcycle,
        Housewagon,
        Trailer
    }

    public class TotalParkTime
    {
        public DateTime TimeOut { get; set; }
        public DateTime TotalTime  { get; set; }


    }
}