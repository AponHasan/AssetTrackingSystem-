using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    class OrganizationBranch
    {
     
        public int OrganizationBranchID { get; set; }
        [Required]
        public int OrganizationID { get; set; }
        [Required]
        public string OrganizationBranchName { get; set; }
        [Required]
        public string OrganizatioBranchShortName { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<AssetLocation> AssetLocations { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
