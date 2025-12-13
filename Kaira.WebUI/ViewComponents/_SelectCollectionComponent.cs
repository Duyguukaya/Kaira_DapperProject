using Kaira.WebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class _SelectCollectionComponent(ICollectionRepository _collectionRepository): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _collectionRepository.GetAllAsync();

            var selectCollection = values.FirstOrDefault(x => x.CollectionId == 3);

            return View(selectCollection);
        }
    }
}
