using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bootstrap.Repositories.Base;
using Bootstrap.Repositories.Contract;
using Bootstrap1.Models;
using Bootstrapdb;
using Microsoft.EntityFrameworkCore;

namespace Bootstrap.Repositories
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        private DbContext db;

        public ProjectDbContext Context
        {
            get { return (ProjectDbContext) db; }
        }
        public ProductRepository(DbContext db) : base(db)
        {
            this.db = (ProjectDbContext) db;
        }


        public ICollection<Product> GetAllProductsWithCategory()
        {
            return Context.Products.Include(c => c.Catagories).Where(c=>c.SubCategories.ToString() == "Latest").ToList();
        }

        public ICollection<Product> GetAllWonemProduct()
        {
            return Context.Products.Where(c => c.SubCategories.SubName == "Women").ToList();
        }

        public ICollection<Product> GetAllMenProduct()
        {
            return Context.Products.Where(c => c.SubCategories.SubName == "Men").ToList();
            
        }
    }
}
