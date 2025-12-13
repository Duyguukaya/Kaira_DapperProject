using Kaira.WebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents
{
    public class _CollectionComponent(ICollectionRepository _collectionRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var collection = await _collectionRepository.GetAllAsync();
            return View(collection);
        }
    }
}
