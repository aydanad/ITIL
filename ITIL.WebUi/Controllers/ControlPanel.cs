using ITIL.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ITIL.WebUi.Controllers
{
    public class ControlPanel : Controller
    {
        private readonly IPersonServices _personService;
        public ControlPanel(IPersonServices personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
