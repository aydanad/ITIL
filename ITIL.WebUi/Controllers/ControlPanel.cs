using ITIL.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ITIL.WebUi.Controllers
{
    public class ControlPanel : Controller
    {
        private readonly IPersonServices _personService;
        private readonly ICityService _cityService;
        public ControlPanel(IPersonServices personService,ICityService cityService)
        {
            _personService = personService;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CityList()
        {
            var cities = await _cityService.GetAllAsync();
            return View(cities);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (await _cityService.RemoveAsync(id, default))
            {
                return RedirectToAction(nameof(CityList));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePage(Guid id)
        {
            var city = await _cityService.GetAsync(id);
            if (city == null) return NotFound();
            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCityDto cityDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _cityService.UpdateAsync(cityDto, default);
                if (result)
                {
                    return RedirectToAction(nameof(CityList));
                }
            }
            return View(cityDto);
        }
    }
}
