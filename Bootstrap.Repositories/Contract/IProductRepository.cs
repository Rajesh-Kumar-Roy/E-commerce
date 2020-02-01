using System;
using System.Collections.Generic;
using System.Text;
using Bootstrap1.Models;

namespace Bootstrap.Repositories.Contract
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        ICollection<Product> GetAllProductsWithCategory();
        ICollection<Product> GetAllWonemProduct();
        ICollection<Product> GetAllMenProduct();
    }
}
