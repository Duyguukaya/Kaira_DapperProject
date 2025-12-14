using Kaira.WebUI.Dtos.MarkaDtos;
using Kaira.WebUI.Repositories.MarkaRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    [Authorize]
    public class MarkaController(IMarkaRepository _markaRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var marka = await _markaRepository.GetAllAsync();
            return View(marka);
        }


        public async Task<IActionResult> CreateMarka()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateMarka(CreateMarkaDto markaDto)
        {
            await _markaRepository.CreateAsync(markaDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateMarka(int id)
        {
            var marka = await _markaRepository.GetByIdAsync(id);
            return View(marka);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMarka(UpdateMarkaDto markaDto)
        {
            await _markaRepository.UpdateAsync(markaDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteMarka(int id)
        {
            await _markaRepository.DeleteAsync(id);
            return RedirectToAction("Index");

        }
    }
}
