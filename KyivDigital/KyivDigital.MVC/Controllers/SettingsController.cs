using Microsoft.AspNetCore.Mvc;
namespace KyivDigital.MVC.Controllers
{
    [Route("settings")]
    public class SettingsController : Controller
    {
        public IActionResult Index() => View();
    }
}