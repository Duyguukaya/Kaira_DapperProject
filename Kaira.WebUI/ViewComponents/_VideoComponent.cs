using Kaira.WebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents
{
    public class _VideoComponent(IVideoRepository _videoRepository) :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var video = await _videoRepository.GetAllAsync();
            var videos = video.FirstOrDefault();
            return View(videos);
        }
    }
}
