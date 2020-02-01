using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Bootstrap1.Models
{
    public class SubCategories
    {
        public int Id { get; set; }
        public string SubName { get; set; }
        public string Code { get; set; }
        public bool IsDelete { get; set; }
        public string Image { get; set; }
        [ForeignKey("Catagories")]
        public int CategoriesId { get; set; }
        public Catagories Catagories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
