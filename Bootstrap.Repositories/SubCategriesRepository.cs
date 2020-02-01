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
    public class SubCategriesRepository:BaseRepository<SubCategories>,ISubCategoriesRepository
    {
        private DbContext db;

        public ProjectDbContext Context
        {
            get { return (ProjectDbContext) db; }
        }
        public SubCategriesRepository(DbContext db) : base(db)
        {
            this.db = (ProjectDbContext)db;
        }


        public ICollection<SubCategories> GetAllSubCategoriesesWithCategorieses()
        {
            return Context.SubCategorieses.Include(c => c.Catagories).ToList();
        }

        public ICollection<SubCategories> GetAllproductsWithsubcategories()
        {
            return Context.SubCategorieses.Include(c => c.Products).ToList();
        }
    }
}
