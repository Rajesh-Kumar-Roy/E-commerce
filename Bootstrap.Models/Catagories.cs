using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootstrap1.Models
{
    public class Catagories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<SubCategories> SubCategorieses { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
