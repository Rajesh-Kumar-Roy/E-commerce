using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Manager.IContract;
using Bootstrap1.Utiliites.IUitilites;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bootstrap1.Utiliites
{
    public class DropDownUtilities:IUtilitiesManager
    {
        private readonly ICategoriesManager _categoriesManager;
        private readonly ISubCategoriesManger _subCategoriesManger;

        public DropDownUtilities(ICategoriesManager categoriesManager,ISubCategoriesManger subCategoriesManger)
        {
            _categoriesManager = categoriesManager;
            _subCategoriesManger = subCategoriesManger;
        }
        public ICollection<SelectListItem> GetAllCategories()
        {
            return _categoriesManager.GetByAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        public ICollection<SelectListItem> GetAllSubCategories()
        {
            return _subCategoriesManger.GetByAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.SubName
            }).ToList();
        }
    }
}
