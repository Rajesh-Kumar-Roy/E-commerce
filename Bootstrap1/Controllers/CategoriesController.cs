using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Manager.IContract;
using Bootstrap1.Areas.Identity.Data;
using Bootstrap1.Models;
using Bootstrap1.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Bootstrap1.Controllers
{
  
    public class CategoriesController : Controller
    {
        private readonly ICategoriesManager _catagoriesManger;
        public CategoriesController(ICategoriesManager catagoriesManger)
        {
            _catagoriesManger = catagoriesManger;
        }
        // GET: Categories
        public ActionResult Index()
        {

         var cateModel=new List<CatagoriesViewModel>();
          
            var categories = _catagoriesManger.GetByAll();
            if (categories == null)
            {
                return NotFound();
            }
            foreach (var category in categories)
            {
                var model = new CatagoriesViewModel();
                model.Id = category.Id;
                model.Name = category.Name;
                model.Stock = category.Stock;
                cateModel.Add(model);
            }
            
            return View(cateModel);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            var Categories = _catagoriesManger.GetById(id);
            if (Categories == null)
            {
                return NotFound();
            }

            var model =new  CatagoriesViewModel();
            model.Id = Categories.Id;
            model.Name = Categories.Name;
            model.Stock = Categories.Stock;
            return View(model);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatagoriesViewModel model)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    var categories = new Catagories();
                    categories.Id = model.Id;
                    categories.Name = model.Name;
                    categories.Stock = model.Stock;
                    
                  bool isSave=  _catagoriesManger.Add(categories);
                    // TODO: Add insert logic here
                    if (isSave)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return NotFound();
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            var categories = _catagoriesManger.GetById(id);
            if (categories == null)
            {
                return NotFound();
            }

            var model = new CatagoriesViewModel();
            model.Id = categories.Id;
            model.Name = categories.Name;
            model.Stock = categories.Stock;
            return View(model);
        }

        // POST: Categories/Edit/5
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

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
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