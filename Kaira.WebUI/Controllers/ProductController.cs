using Kaira.WebUI.Dtos.ProductDtos;
using Kaira.WebUI.Repositories.CategoryRepositories;
using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Kaira.WebUI.Controllers
{
    [Authorize]
    public class ProductController(IProductRepository _productRepository,ICategoryRepository _categoryRepository) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> CreateProuduct()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProuduct(CreateProductDto productDto)
        {
            await _productRepository.CreateAsync(productDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateProuduct(int id)
        {
            await GetCategoriesAsync();
            var product = await _productRepository.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProuduct(UpdateProductDto productDto)
        {
            await _productRepository.UpdateAsync(productDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProuduct(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
