using KyivDigital.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace KyivDigital.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
    }
}