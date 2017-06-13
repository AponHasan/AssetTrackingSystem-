using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class GeneralCategory
    {
        public int GeneralCategoryID { get; set; }
        [Required]
        [Display(Name = "General Category Name")]
        public string GeneralCategoryName { get; set; }

        [Required]
        [Display(Name = "General Category Code")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string GeneralCategoryCode { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
