using Bootstrap1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bootstrapdb
{
    public class ProjectDbContext:DbContext
    {
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BootstrapDb;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategories> SubCategorieses { get; set; }
        public DbSet<Catagories> Catagorieses { get; set; }
    }
}
