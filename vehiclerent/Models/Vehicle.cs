using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vehiclerent.Models
{
    public class Vehicle
    {
        [Key, Display(Name = "Vehicle Id"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Id")]
        public String VehicleId { set; get; }

        [Display(Name = "Vehicle Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Type")]
        public String VehicleType { set; get; }

        [Display(Name = "Vehicle Model")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Model")]
        public String VehicleModel { set; get; }

        [Display(Name = "Vehicle Image")]
        [DataType(DataType.ImageUrl)]
        public String Image { set; get; }

        [Display(Name = "Vehicle Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Model")]
        public float price { set; get; }

        [Display(Name = "Vehicle Capacity")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Model")]
        public int capacity { set; get; }

        [Display(Name = "Vehicle Doors")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Model")]
        public int doors { set; get; }

        [Display(Name = "Vehicle Aircondition")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Model")]
        public String air { set; get; }

        [Display(Name = "Vehicle transmission")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Model")]
        public String transmission { set; get; }

        [Display(Name = "Vehicle Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Vehicle Model")]
        public String Description { set; get; }

        public String RenterEMail { get; set; }
        //[ForeignKey("RenterEMail")]
        public virtual Renter renter { set; get; }
        
        //public ICollection<VehicleAvailability> vavailability { set; get; }

       
    }
}