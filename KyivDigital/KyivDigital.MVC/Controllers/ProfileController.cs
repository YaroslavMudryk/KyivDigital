using KyivDigital.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KyivDigital.MVC.Controllers
{
    [Authorize]
    [Route("profile")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        //public async Task<IActionResult> Index() => View(await _userService.GetUserProfileAsync());
        public IActionResult Index() => View();
    }
}
