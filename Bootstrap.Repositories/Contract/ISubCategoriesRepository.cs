using System;
using System.Collections.Generic;
using System.Text;
using Bootstrap1.Models;

namespace Bootstrap.Repositories.Contract
{
    public interface ISubCategoriesRepository:IBaseRepository<SubCategories>
    {
        ICollection<SubCategories> GetAllSubCategoriesesWithCategorieses();
        ICollection<SubCategories> GetAllproductsWithsubcategories();
    }
}
