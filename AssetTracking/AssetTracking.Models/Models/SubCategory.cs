using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    class SubCategory
    {
        public int SubCategoryID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string SubCategoryName { get; set; }

        [Required]
        public string SubCategoryCode { get; set; }

        [Required]
        public string SubCategoryDescription { get; set; }

        public virtual Category Category { get; set; }
    }
}
