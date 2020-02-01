using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bootstrap1.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string ProductModel { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
  
        public IFormFile Image { get; set; }

       
        public int CatagoriesId { get; set; }
        public Catagories Catagories { get; set; }

       
        public int SubCategoriesId { get; set; }
        public SubCategories SubCategories { get; set; }
        public ICollection<SelectListItem> GetAllCategories { get; set; }
        public ICollection<SelectListItem> GetAllSubCategories { get; set; }

    }
}
