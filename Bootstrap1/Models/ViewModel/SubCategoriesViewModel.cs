using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bootstrap1.Models.ViewModel
{
    public class SubCategoriesViewModel
    {
        public int Id { get; set; }
        public string SubName { get; set; }
        public string Code { get; set; }
        public IFormFile Image { get; set; }
        
        public int CategoriesId { get; set; }
        public Catagories Catagories { get; set; }
        public ICollection<SelectListItem> GetCategories { get; set; }
        public ICollection<Product> Products { get; set; }  
    }
}
