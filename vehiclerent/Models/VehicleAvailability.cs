using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vehiclerent.Models
{
    public class VehicleAvailability
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvailabilityId { set; get; }

        public String VehicleId { set; get; }

        public String VehicleAvailableFrom { set; get; }

        public String VehicleAvailableTo { set; get; }

        public String VehicleLocation { set; get; }

        [Display(Name = "Vehicle latitude")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Latitude")]
        public float latitude { set; get; }

        [Display(Name = "Vehicle longitude")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Longitude")]
        public float longitude { set; get; }
    }
}