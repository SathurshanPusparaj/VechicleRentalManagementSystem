using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vehiclerent.Models
{
    public class Tenant
    {
        [Key, Display(Name = "Tenant E-Mail"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your Email Address")]
        public String TenantEMail { set; get; }

        [Display(Name = "Tenant Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Password")]
        public String TenantPassword { set; get; }

        [Display(Name = "Tenant Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Name")]
        public String TenantName { set; get; }

        [Display(Name = "Tenant NIC Number")]
        [MaxLength(10)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the NIC Number")]
        public String TenantNICNo { set; get; }

        [Display(Name = "Tenant Telephone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the Telephone Number")]
        public String TenantTpNo { set; get; }

        [NotMapped]
        public bool TenantRememberMe { set; get; }
    }
}