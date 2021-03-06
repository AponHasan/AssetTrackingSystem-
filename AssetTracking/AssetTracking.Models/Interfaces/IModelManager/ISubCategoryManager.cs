﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Models.Models;

namespace AssetTracking.Models.Interfaces.IModelManager
{
    public interface ISubCategoryManager : IManager<SubCategory>
    {
        ICollection<SubCategory> GetSubCategoryByCategory(long categoryId);
    }
}
