using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    class Organization
    {

    
        public int OrganizationID { get; set; }
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string OrganizationShortName { get; set; }
        [Required]
        public string OrganizationLocation { get; set; }

        public virtual ICollection<OrganizationBranch> OrganizationBranches { get; set; }
    }

}
