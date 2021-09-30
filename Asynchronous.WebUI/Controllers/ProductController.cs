using Asynchronous.Entity.Concrete;
using Asynchronous.Service.ProductService;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Asynchronous.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ActionResult> Index(int page = 1)
        {
            var productList = await _productService.GetAllIncluding();
            return View(productList.ToPagedList(page, 15));
        }
        public async Task<ActionResult> Category(int id, int page = 1)
        {
            var product = await _productService.GetProductByCategory(id);
            return View(product.ToPagedList(page, 15));
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await _productService.GetCategoryForProduct();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(model);
            }
            return RedirectToAction(nameof(Create));
        }
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Categories = await _productService.GetCategoryForProduct();
            var updateProduct = await _productService.GetById(id);
            if (updateProduct != null)
            {
                return View(updateProduct);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(model);
            }
            return RedirectToAction(nameof(Edit));
        }
        public async Task<ActionResult> Delete(int id)
        {
            var deleteProduct = await _productService.GetById(id);
            if (deleteProduct != null)
            {
                await _productService.Delete(deleteProduct);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Active(int id)
        {
            await _productService.SetActive(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> DeActive(int id)
        {
            await _productService.SetDeActive(id);
            return RedirectToAction(nameof(Index));
        }
    }
}