using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class AssetPurchaseDetail
    {
      
        public int AssetPurchaseDetailID { get; set; }

        [Required]
        [Display(Name = "Asset Purchase Header")]
        public int AssetPurchaseHeaderID { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        public bool IsWarranty { get; set; }

        [Required]
        [Display(Name = "Warranty Period")]
        public double WarrantyPeriod { get; set; }

        [Required]
        [Display(Name = "Warranty Period Unit")]
        public double WarrantyPeriodUnitID { get; set; }

        public virtual WarrantyPeriodUnit WarrantyPeriodUnit { get; set; }
        public virtual AssetPurchaseHeader AssetPurchaseHeader { get; set; }       
        public virtual Category Category { get; set; }
        public virtual ICollection<AssetPurchaseDetailSerialNumber> AssetPurchaseDetailSerialNumbers { get; set; }
    }
}
