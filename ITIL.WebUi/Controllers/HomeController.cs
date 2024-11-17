using ITIL.Services;
using ITIL.Services.Contract;
using ITIL.WebUi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITIL.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonServices _personService;
        public HomeController(ILogger<HomeController> logger, IPersonServices personServices)
        {
            _personService=personServices;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //await _personService.InsertAsync(new CreatePersonDto
            //{
            //    FirstName = "test1",
            //    LastName = "testLastName",
            //    NationalCode = "1231231231",

            //}, CancellationToken.None);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
