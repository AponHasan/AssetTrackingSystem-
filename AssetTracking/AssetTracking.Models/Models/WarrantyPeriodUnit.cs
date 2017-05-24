using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Models
{
    class WarrantyPeriodUnit
    {
        public int WarrantyPeriodUnitID { get; set; }

        [Required]
        public string WarrantyPeriodUnitName { get; set; }
    }
}
