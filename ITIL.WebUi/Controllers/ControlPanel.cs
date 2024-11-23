using ITIL.Domin.Entities;
using ITIL.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<IActionResult> RemoveCity(Guid id)
        {
            if (await _cityService.RemoveAsync(id, default))
            {
                return RedirectToAction(nameof(CityList));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCity(Guid id)
        {
            var city = await _cityService.GetAsync(id);
            if (city == null) return NotFound();
            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCity(UpdateCityDto cityDto)
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
        [HttpGet]
        public IActionResult CreateCity()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCityDto createCityDto)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "این شهر قبلاً وجود دارد.");
                return RedirectToAction(nameof(CreateCity));
            }
            else
            {
                await _cityService.InsertAsync(createCityDto, default);
                return RedirectToAction(nameof(CityList));
            }
            return View(createCityDto);
        }
    }
}
