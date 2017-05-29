using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class Designation
    {
    
        public int DesignationID { get; set; }

        [Required]
        [Display(Name = "Designation Name")]
       public string DesignationName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
