using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class AssetPurchaseDetailSerialNumber
    {
        public int AssetPurchaseDetailSerialNumberID { get; set; }
        [Required]
        [Display(Name = "Perchase Detail")]
        public int PerchaseDetailID { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        public virtual AssetPurchaseDetail AssetPurchaseDetail { get; set; }
    }
}
