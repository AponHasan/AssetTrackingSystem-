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
        public int VendorID { get; set; }

        [Required]
        public int ProductCategoryID { get; set; }
        [Required]
        public double WarrantyPeriodUnitID { get; set; }
        [Required]
        public int OrganizationBranchID { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        public bool IsWarranty { get; set; }
        [Required]
        public double WarrantyPeriod { get; set; }


        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public DateTime PurchasedOn { get; set; }

        [Required]
        public int PurchasedBy { get; set; }

      

        public virtual WarrantyPeriodUnit WarrantyPeriodUnit { get; set; }
    }
}
