using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    class Vendor
    {
        public int VendorID { get; set; }

        [Required]
        public string VendorName { get; set; }
    }
}
