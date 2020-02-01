using System;
using System.Collections.Generic;
using System.Text;
using Bootstrap1.Models;

namespace Bootstrap.Manager.IContract
{
    public interface IProductManager:IBaseManager<Product>
    {
        ICollection<Product> GetAllProductsWithCategory();
        ICollection<Product> GetAllWonemProduct();
        ICollection<Product> GetAllMenProduct();
    }
}
