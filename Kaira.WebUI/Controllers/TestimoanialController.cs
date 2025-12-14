using Kaira.WebUI.Dtos.CategoryDtos;
using Kaira.WebUI.Dtos.TestimonialDtos;
using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    [Authorize]
    public class TestimoanialController(ITestimonialRepository _testimonialRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var testmonial = await _testimonialRepository.GetAllAsync();
            return View(testmonial);
        }


        public async Task<IActionResult> CreateTestimoanial()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTestimoanial(CreateTestimonialDto testimonialDto)
        {
            await _testimonialRepository.CreateAsync(testimonialDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateTestimoanial(int id)
        {
            var testimonial = await _testimonialRepository.GetByIdAsync(id);
            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimoanial(UpdateTestimonialDto testimonialDto)
        {
            await _testimonialRepository.UpdateAsync(testimonialDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteTestimoanial(int id)
        {
            await _testimonialRepository.DeleteAsync(id);
            return RedirectToAction("Index");

        }
    }
}
