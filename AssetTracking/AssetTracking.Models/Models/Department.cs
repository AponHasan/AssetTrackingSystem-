﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required]
        [Display(Name = "Organization Branch")]
        public int OrganizationBranchID { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        public virtual OrganizationBranch OrganizationBranch { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
