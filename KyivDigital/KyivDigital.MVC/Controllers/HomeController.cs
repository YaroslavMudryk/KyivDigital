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
        private readonly ISessionService _sessionService;

        public HomeController(ILogger<HomeController> logger, IFeedService feedService, ISessionService sessionService)
        {
            _logger = logger;
            _feedService = feedService;
            _sessionService = sessionService;
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
            var page = GetPage();
            if (GetMaxPage() != -1)
                if (page > GetMaxPage())
                    return StatusCode(204);
            var count = GetCount();
            var response = await _feedService.GetPagedUserHistoryAsync(page, count);
            SetMaxPage(response.Feed.Meta.Pagination.TotalPages);
            if (response.Feed.Data == null || response.Feed.Data.Count == 0)
            {
                return StatusCode(204);
            }
            return PartialView(response);
        }

        #region DataPagination
        private int GetPage()
        {
            var maxPages = GetMaxPage();
            var page = _sessionService.GetSessionValue<int>("Page");
            if (page == 0)
            {
                page = 1;
                _sessionService.SetSessionValue("Page", page);
            }
            else
            {
                _sessionService.SetSessionValue("Page", ++page);
            }
            return page;
        }

        private int GetCount()
        {
            var count = _sessionService.GetSessionValue<int>("Count");
            if (count != 20)
            {
                count = 20;
                _sessionService.SetSessionValue("Count", count);
            }
            return count;
        }
        #endregion

        #region Pagination
        private int GetMaxPage()
        {
            var res = _sessionService.GetSessionValue<int>("MaxFeedPage");
            return res == 0 ? -1 : res;
        }

        private void SetMaxPage(int maxPages)
        {
            _sessionService.SetSessionValue("MaxFeedPage", maxPages);
        }
        #endregion
    }
}