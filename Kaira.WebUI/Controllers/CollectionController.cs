using Kaira.WebUI.Dtos.CategoryDtos;
using Kaira.WebUI.Dtos.CollectionDtos;
using Kaira.WebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    [Authorize]
    public class CollectionController(ICollectionRepository _collectionRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collections = await _collectionRepository.GetAllAsync();
            return View(collections);
        }


        public async Task<IActionResult> CreateCollection()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCollection(CreateCollectionDto collectionDto)
        {
            await _collectionRepository.CreateAsync(collectionDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateCollection(int id)
        {
            var collection  = await _collectionRepository.GetByIdAsync(id);
            return View(collection);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCollection(UpdateCollectionDto collectionDto)
        {
            await _collectionRepository.UpdateAsync(collectionDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteCollection(int id)
        {
            await _collectionRepository.DeleteAsync(id);
            return RedirectToAction("Index");

        }
    }
}
