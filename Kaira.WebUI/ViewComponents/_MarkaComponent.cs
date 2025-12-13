using Kaira.WebUI.Repositories.MarkaRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents
{
    public class _MarkaComponent(IMarkaRepository _markaRepository):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var marka = await _markaRepository.GetAllAsync();
            return View(marka);
        }
    }
}
