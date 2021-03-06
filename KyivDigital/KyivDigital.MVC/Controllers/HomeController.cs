using KyivDigital.Business.Services.Interfaces;
using KyivDigital.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace KyivDigital.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeedService _feedService;

        public HomeController(ILogger<HomeController> logger, IFeedService feedService)
        {
            _logger = logger;
            _feedService = feedService;
        }

        public IActionResult Index() => View();

        [HttpGet("start")]
        [AllowAnonymous]
        public IActionResult Start() => View();

        [AllowAnonymous]
        [HttpGet("error")]
        public IActionResult Error(ErrorViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Error))
                return View(new ErrorViewModel { StatusCode = 404, Error = "Сторінка не знайдена", Title = "Not found" });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> _FeedData()
        {
            var response = await _feedService.GetPagedUserHistoryAsync();
            if (response == null || (response.Feed.Data == null || response.Feed.Data.Count == 0))
            {
                return StatusCode(204);
            }
            return PartialView(response);
        }
    }
}