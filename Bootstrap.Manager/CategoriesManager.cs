using System;
using System.Collections.Generic;
using System.Text;
using Bootstrap.Manager.Base;
using Bootstrap.Manager.IContract;
using Bootstrap.Repositories.Contract;
using Bootstrap1.Models;

namespace Bootstrap.Manager
{
    public class CategoriesManager:BaseManager<Catagories>,ICategoriesManager
    {
        private ICategoriesRepository _categoriesRepository;
        public CategoriesManager(ICategoriesRepository categoriesRepository):base(categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
    }
}
