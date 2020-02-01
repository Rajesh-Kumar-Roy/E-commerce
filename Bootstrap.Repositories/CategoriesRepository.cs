using System;
using System.Collections.Generic;
using System.Text;
using Bootstrap.Repositories.Base;
using Bootstrap.Repositories.Contract;
using Bootstrap1.Models;
using Bootstrapdb;
using Microsoft.EntityFrameworkCore;

namespace Bootstrap.Repositories
{
    public class CategoriesRepository:BaseRepository<Catagories>,ICategoriesRepository
    {
        private DbContext db;

        private ProjectDbContext context
        {
            get { return (ProjectDbContext) db; }
        }
        public CategoriesRepository(DbContext db):base(db)
        {
            this.db = (ProjectDbContext) db;
        }


    }
}
