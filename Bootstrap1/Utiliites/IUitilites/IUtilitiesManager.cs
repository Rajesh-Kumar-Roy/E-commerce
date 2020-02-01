using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Manager.IContract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bootstrap1.Utiliites.IUitilites
{
    public interface IUtilitiesManager
    {
        ICollection<SelectListItem> GetAllCategories();
        ICollection<SelectListItem> GetAllSubCategories();
    }
}
