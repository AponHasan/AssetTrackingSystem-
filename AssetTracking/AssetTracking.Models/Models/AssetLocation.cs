using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class AssetLocation
    {
        
        public int AssetLocationID { get; set; }
        [Required]
        [Display(Name = "Organization Branch")]
        public int OrganizationBranchID { get; set; }

        [Required]
        [Display(Name = "Asset Location")]
        public string AssetLocationName { get; set; }

        [Required]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }
        public virtual OrganizationBranch OrganizationBranch { get; set; }
    }
}
