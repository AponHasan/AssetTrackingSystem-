using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class Employee
    {

        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public int DesignationID { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNo { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }

    }
}
