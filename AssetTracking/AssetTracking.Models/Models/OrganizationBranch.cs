﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class OrganizationBranch
    {
     
        public int OrganizationBranchID { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public int OrganizationID { get; set; }

        [Required]
        [Display(Name = "Organization Branch Name")]
        public string OrganizationBranchName { get; set; }

        [Required]
        [Display(Name = "Organization Branch Short Name")]
        public string OrganizatioBranchShortName { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<AssetLocation> AssetLocations { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
