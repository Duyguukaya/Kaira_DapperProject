using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _Last4ProductComponent(IProductRepository _productRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productRepository.GetAllAsync();
            var last4Products = values.OrderByDescending(x => x.ProductId).Take(4).ToList();
            return View(last4Products);
        }
    }
}
