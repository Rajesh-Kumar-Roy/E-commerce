using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bootstrap1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string ProductModel { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsDelete { get; set; }
        [ForeignKey("Catagories")]
        public int CatagoriesId { get; set; }
        public Catagories Catagories { get; set; }

        [ForeignKey("SubCategories")]
        public int SubCategoriesId { get; set; }
        public SubCategories SubCategories { get; set; }


    }
}
