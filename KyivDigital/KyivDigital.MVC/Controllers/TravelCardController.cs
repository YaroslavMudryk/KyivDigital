using KyivDigital.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;
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
        public async Task<IActionResult> Index()
        {
            var cards = await _travelCardService.GetTravelCardsAsync();

            foreach (var card in cards.Cards)
            {
                card.Code = card.Code.Group();
            }

            return View(cards.Cards);
        }


        

    }

    public static class Dwe
    {
        public static string Group(this string s, int groupSize = 4, char groupSeparator = ' ')
        {
            var formattedIdentifierBuilder = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (i != 0 && (s.Length - i) % groupSize == 0)
                {
                    formattedIdentifierBuilder.Append(groupSeparator);
                }

                formattedIdentifierBuilder.Append(s[i]);
            }

            return formattedIdentifierBuilder.ToString();
        }
    }
}
