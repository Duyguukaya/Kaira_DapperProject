using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _First4ProductComponent(IProductRepository _productRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var allProducts = await _productRepository.GetAllAsync();
            var first2 = allProducts.Take(2).ToList();
            var last2 = allProducts.TakeLast(2).ToList();
            var result = first2.Concat(last2).Distinct().ToList();

            return View(result);
        }
    }
}
