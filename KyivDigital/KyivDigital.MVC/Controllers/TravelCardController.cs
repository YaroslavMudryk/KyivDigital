using KyivDigital.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KyivDigital.MVC.Controllers
{
    [Route("eticket")]
    public class TravelCardController : Controller
    {
        private readonly ITravelCardService _travelCardService;
        public TravelCardController(ITravelCardService travelCardService)
        {
            _travelCardService = travelCardService;
        }


        //public IActionResult Index() => View();
        public async Task<IActionResult> Index() => View((await _travelCardService.GetTravelCardsAsync()).Cards);
    }
}
