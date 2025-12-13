using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents
{
    public class _TestimonialComponent(ITestimonialRepository _testimonialRepository): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonial = await _testimonialRepository.GetAllAsync();
            return View(testimonial);
        }
    }
}
