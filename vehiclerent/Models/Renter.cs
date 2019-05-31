using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vehiclerent.Models
{
    public class Renter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your Email Address")]
        public String RenterEMail { set; get; }


        [Display(Name = "Renter Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Name")]
        public String RenterName { set; get; }

        [Display(Name = "Renter NIC Number")]
        [MaxLength(10)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the NIC Number")]
        public String RenterNICNo { set; get; }

        [Display(Name = "Renter Telephone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Telephone Number")]
        public String RenterTpNo { set; get; }

        [Display(Name = "Renter Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Password")]
        public String RenterPassword { set; get; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("RenterPassword", ErrorMessage = "Password Not matched")]
        public String RenterConfirmpassword { set; get; }

        [Display(Name = "Renter about")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Password")]
        public String about{ set; get; }

        [NotMapped]
        public bool RenterRememberMe { set; get; }

        public ICollection<Vehicle> Rentervehicles { set; get; }
    }
}