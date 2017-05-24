using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    class Employee
    {

        public int EmployeeID { get; set; }

        [Required]

        public int DepartmentID { get; set; }

        [Required]

        public string EmployeeName { get; set; }

        [Required]
        public int DesignationID { get; set; }

        [Required]

        public string ContactNo { get; set; }

        [Required]

        public string Email { get; set; }

        public Department Department { get; set; }
        public Designation Designation { get; set; }

    }
}
