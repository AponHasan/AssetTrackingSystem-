using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    class Department
    {
        public int DepartmentID { get; set; }
        [Required]
        public int OrganizationBranchID { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        public virtual OrganizationBranch OrganizationBranch { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
