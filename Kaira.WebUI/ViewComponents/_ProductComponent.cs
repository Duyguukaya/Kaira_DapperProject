using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _ProductComponent(IProductRepository _productRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productRepository.GetAllAsync();
            var first4Products = values.Take(4).ToList();

            return View(first4Products);
        }
    }
}
