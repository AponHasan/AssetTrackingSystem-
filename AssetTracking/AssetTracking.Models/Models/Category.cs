using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]    
        public int GeneralCategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string CategoryCode { get; set; }

        [Required]
        public string CategoryDescription { get; set; }

        public virtual GeneralCategory GeneralCategory { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
