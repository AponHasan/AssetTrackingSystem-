using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    class GeneralCategory
    {
        public int GeneralCategoryID { get; set; }
        [Required]
        public string GeneralCategoryName { get; set; }

        [Required]
        public string GeneralCategoryCode { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
