using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class Vendor
    {
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
    }
}
