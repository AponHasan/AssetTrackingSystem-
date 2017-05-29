using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class AssetPurchaseSerialNumber
    {
        public int AssetPurchaseSerialNumberID { get; set; }
        [Required]
        [Display(Name = "Asset PurchaseDetail")]
        public int AssetPurchaseDetailID { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        public virtual AssetPurchaseDetail AssetPurchaseDetail { get; set; }
    }
}
