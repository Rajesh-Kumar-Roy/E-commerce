using System;
using System.Collections.Generic;
using System.Text;
using Bootstrap1.Models;

namespace Bootstrap.Manager.IContract
{
    public interface ISubCategoriesManger:IBaseManager<SubCategories>
    {
        ICollection<SubCategories> GetAllSubCategoriesesWithCategorieses();
        ICollection<SubCategories> GetAllproductsWithsubcategories();
    }
}
