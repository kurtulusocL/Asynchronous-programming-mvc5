using Asynchronous.Entity.Concrete;
using Asynchronous.Service.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Asynchronous.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Index()
        {
            var categoryList = await _categoryService.GetAllIncluding();
            return View(categoryList);          
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Create(model);
            }
            return RedirectToAction(nameof(Create));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var updateCategory = await _categoryService.GetById(id);
            if (updateCategory!=null)
            {
                return View(updateCategory);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(model);
            }
            return RedirectToAction(nameof(Edit));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var deleteCategory = await _categoryService.GetById(id);
            if (deleteCategory != null)
            {
               await _categoryService.Delete(deleteCategory);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Active(int id) 
        {
            await _categoryService.SetActive(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> DeActive(int id)
        {
            await _categoryService.SetDeActive(id);
            return RedirectToAction(nameof(Index));
        }
    }
}