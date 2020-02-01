using System;
using System.Collections.Generic;
using System.Text;
using Bootstrap.Manager.Base;
using Bootstrap.Manager.IContract;
using Bootstrap.Repositories.Contract;
using Bootstrap1.Models;

namespace Bootstrap.Manager
{
    public class SubCategoriesManger:BaseManager<SubCategories>,ISubCategoriesManger
    {
        private ISubCategoriesRepository _subCategoriesRepository;
        public SubCategoriesManger( ISubCategoriesRepository subCategoriesRepository) : base(subCategoriesRepository)
        {
            _subCategoriesRepository = subCategoriesRepository;
        }

        public ICollection<SubCategories> GetAllSubCategoriesesWithCategorieses()
        {
            return _subCategoriesRepository.GetAllSubCategoriesesWithCategorieses();
        }

        public ICollection<SubCategories> GetAllproductsWithsubcategories()
        {
            return _subCategoriesRepository.GetAllproductsWithsubcategories();
        }
    }
}
