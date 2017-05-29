using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class Organization
    {

    
        public int OrganizationID { get; set; }
        [Required]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Required]
        [Display(Name = "Organization Short Name")]
        public string OrganizationShortName { get; set; }

        [Required]
        [Display(Name = "Organization Location")]
        public string OrganizationLocation { get; set; }

        public virtual ICollection<OrganizationBranch> OrganizationBranches { get; set; }
    }

}
