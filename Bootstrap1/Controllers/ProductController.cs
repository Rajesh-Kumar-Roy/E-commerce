using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Manager.IContract;
using Bootstrap1.Models;
using Bootstrap1.Models.ViewModel;
using Bootstrap1.Utiliites.IUitilites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Bootstrap1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly IUtilitiesManager _utilities;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ProductController(IProductManager productManager,IUtilitiesManager utilities,IHostingEnvironment hostingEnvironment)
        {
            _productManager = productManager;
            _utilities = utilities;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: Product
        public ActionResult Index()
        {
            var product = _productManager.GetByAll();
            if (product == null)
            {
                return NotFound();
            }
            //List<ProductViewModel> list = new List<ProductViewModel>();
            //foreach (var pro in product)
            //{
            //    var model = new ProductViewModel();
            //    model.Id = pro.Id;
            //    model.Name = pro.Name;
            //    model.Size = pro.Size;
                
            //    model.ProductModel = pro.ProductModel;
            //    model.Description = pro.Description;
            //    model.Price = pro.Price;
            //    model.SubCategoriesId = pro.SubCategoriesId;
            //    model.SubCategories = pro.SubCategories;
            //    model.CatagoriesId = pro.CatagoriesId;
            //    model.Catagories = pro.Catagories;
            //    list.Add(model);
            //}
            return View(product);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = _productManager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            model.GetAllSubCategories = _utilities.GetAllSubCategories();
            model.GetAllCategories = _utilities.GetAllCategories();

            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include:"Id,Name,Price,Size,ProductModel," +
                                                 "Image,Description,CatagoriesId,Catagories,SubCategoriesId,SubCategories")]ProductViewModel model)
        {
            try
            {
              
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                  var product = new Product();
                product.Id = model.Id;
                product.Name = model.Name;
                product.Price = model.Price;
                product.Size = model.Size;
                product.ProductModel = model.ProductModel;
               
                product.Description = model.Description;
                product.CatagoriesId = model.CatagoriesId;
                product.Catagories = model.Catagories;
                product.SubCategoriesId = model.SubCategoriesId;
                product.SubCategories = model.SubCategories;
                string uniquefileName = null;
                if (model.Image != null)
                {
                    string uploadsfolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                    uniquefileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsfolder, uniquefileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                product.Image = uniquefileName;
                var success = _productManager.Add(product);
                if (success)
                {
                    
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
                }

                return View(model);

            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
           var  product = _productManager.GetById(id);
           if (product == null)
           {
               return NotFound();
           }
           return View(product);
        }

        // POST: Product/Delete/5

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
              var product =  _productManager.GetById(id);
              if (product == null)
              {
                  return NotFound();
              }

              var isDelete = _productManager.Remove(product);
              if (isDelete)
              {
                return RedirectToAction(nameof(Index));
              }

               
            }
            catch
            {
                return BadRequest("There have some problem!");
            }
            return RedirectToAction(nameof(Index));
        }

        //Get: Product/ProductHome
        [HttpGet]
        public IActionResult ProductHome()
        {
            var product = _productManager.GetByAll();
            if (product == null)
            {
                return NotFound();
            }
            
            return View(product);
           
        }

        [HttpGet]
        public IActionResult WomenProduct()
        {
            var products = _productManager.GetAllWonemProduct();
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        public IActionResult ManProduct()
        {
            var products = _productManager.GetAllMenProduct();
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return View(products);
            }
        }
    }
}