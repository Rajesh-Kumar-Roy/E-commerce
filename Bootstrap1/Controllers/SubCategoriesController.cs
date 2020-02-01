using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Manager.IContract;
using Bootstrap1.Models;
using Bootstrap1.Models.ViewModel;
using Bootstrap1.Utiliites.IUitilites;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootstrap1.Controllers
{
    public class SubCategoriesController : Controller
    {
        private ISubCategoriesManger _subCategoriesManger;
        private IUtilitiesManager _utilitiesManager;
        private IHostingEnvironment _hostingEnvironment;
        public SubCategoriesController(ISubCategoriesManger subCategoriesManger,IUtilitiesManager utilitiesManager,IHostingEnvironment hostingEnvironment)
        {
            _subCategoriesManger = subCategoriesManger;
            _utilitiesManager = utilitiesManager;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: SubCategories
        public ActionResult Index()
        {
            //var catelist = new List<SubCategoriesViewModel>();
            
            var subCatagories = _subCategoriesManger.GetAllproductsWithsubcategories();
            if (subCatagories == null)
            {
                return NotFound();
            }
            
            //var productlist = new List<Product>();
            //if (subCatagories.Any())
            //{
            //     foreach (var item in subCatagories)
            //     {
                    
            //       foreach (var product in item.Products)
            //       {
            //           var model = new SubCategories();
                       
            //            foreach (var modelProduct in model.Products)
            //            {
            //                modelProduct.Image = product.Image;
            //                modelProduct.Name = product.Name;
            //                modelProduct.Price = product.Price;
            //                modelProduct.Size = product.Size;
            //                modelProduct.ProductModel = product.ProductModel;
            //                productlist.Add(modelProduct);
            //            }
            //       }

                   
            //     }
            //}
           
            //foreach (var subCatagory in subCatagories)
            //{
            //    var model = new SubCategoriesViewModel();
            //    model.Id = subCatagory.Id;
            //    model.SubName = subCatagory.SubName;
            //    model.Code = subCatagory.Code;
            //    model.CategoriesId = subCatagory.CategoriesId;
            //    model.Catagories = subCatagory.Catagories;
            //    model.Products = subCatagory.Products;
            //    catelist.Add(model);
            //}
            return View(subCatagories);
             // ICollection<Product> GetProduct()
             //{
             //   List<Product> product = new List<Product>();
             //   foreach (var item in subCatagories)
             //   {
             //       foreach (var VARIABLE in item.Products)
             //       {
                        
             //       }
             //   }
             //}
        }

       
        // GET: SubCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            var viewModel = new SubCategoriesViewModel();
            viewModel.GetCategories = _utilitiesManager.GetAllCategories();
            return View(viewModel);
        }

        // POST: SubCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include:"Id,Code,SubName,Image,CategoriesId,Catagories")]SubCategoriesViewModel model)
        {
            try
            { 
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var subcategories = new SubCategories();
                    subcategories.Id = model.Id;
                    subcategories.Code = model.Code;
                    subcategories.SubName = model.SubName;
                    subcategories.CategoriesId = model.CategoriesId;
                    subcategories.Catagories = model.Catagories;
                    string uniqueFileName = null;
                    if (model.Image != null)
                    {
                        string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueFileName);
                        model.Image.CopyTo(new FileStream(filePath,FileMode.Create));
                    }

                    subcategories.Image = uniqueFileName;
                    var success = _subCategoriesManger.Add(subcategories);
                    if (success)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return View();
                }
              
                return View(model);

            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubCategories/Edit/5
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

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubCategories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}