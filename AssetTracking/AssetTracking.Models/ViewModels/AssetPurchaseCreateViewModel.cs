using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssetTracking.Models.Models;

namespace AssetTracking.Models.ViewModels
{
   public class AssetPurchaseCreateViewModel
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

       public ICollection<AssetPurchaseHeader> AssetPurchaseHeaders { get; set; }
       public ICollection<Product> Products { get; set; }

        public SelectList ProductdetailsLookup { get; set; }
    }
}
