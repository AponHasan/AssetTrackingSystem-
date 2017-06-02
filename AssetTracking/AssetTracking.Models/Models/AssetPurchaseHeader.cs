using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class AssetPurchaseHeader
    {
       
        public int AssetPurchaseHeaderID { get; set; }

        [Required]
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }

        [Required]
        [Display(Name = "Purchased Date")]
        public DateTime PurchasedOn { get; set; }

        [Display(Name = "Organization Branch")]
        public int OrganizationBranchID { get; set; }

        public virtual OrganizationBranch OrganizationBranch { get; set; }
        public virtual Vendor Vendor { get; set; }
        public ICollection<AssetPurchaseDetail> AssetPurchaseDetails { get; set; }            
    }
}
