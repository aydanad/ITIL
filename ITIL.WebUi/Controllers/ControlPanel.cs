using ITIL.Domin.Entities;
using ITIL.Services.Contract;
using ITIL.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITIL.WebUi.Controllers
{
    public class ControlPanel : Controller
    {
        private readonly IPersonServices _personService;
        private readonly ICityService _cityService;
        private readonly IDepartmentServices _departmentServices;
        public ControlPanel(IPersonServices personService,ICityService cityService, IDepartmentServices departmentServices)
        {
            _personService = personService;
            _cityService = cityService;
            _departmentServices = departmentServices;
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
            if (!ModelState.IsValid)
            {
                await _cityService.InsertAsync(createCityDto, default);
                return RedirectToAction(nameof(CityList));
            }
            else
            {
                ModelState.AddModelError("Title", "این شهر قبلاً وجود دارد.");
                return RedirectToAction(nameof(CreateCity));
            }
            return View(createCityDto);
        }







         public async Task<IActionResult> DepartmentList()
        {
            var departments = await _departmentServices.GetAllAsync();
            return View(departments);
        }
        [HttpGet]
        public async Task<IActionResult> RemoveDepartment(Guid id)
        {
            if (await _cityService.RemoveAsync(id, default))
            {
                return RedirectToAction(nameof(DepartmentList));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(Guid id)
        {
            var departments = await _departmentServices.GetAsync(id);
            if (departments == null) return NotFound();
            return View(departments);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _departmentServices.UpdateAsync(updateDepartmentDto, default);
                if (result)
                {
                    return RedirectToAction(nameof(DepartmentList));
                }
            }
            return View(updateDepartmentDto);
        }
        [HttpGet]
        public async Task<IActionResult> CreateDepartment()
        {
            var cities = await _cityService.GetAllAsync();
            ViewBag.Cities = new SelectList(cities, "Title");
            var departmentTypes = Enum.GetValues(typeof(DepartmentType))
                              .Cast<DepartmentType>()
                              .Select(e => new SelectListItem
                              {
                                  Value = e.ToString(),
                                  Text = e.ToString() 
                              }).ToList();

            ViewBag.DepartmentTypes = departmentTypes;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            if (!ModelState.IsValid)
            {
                await _departmentServices.InsertAsync(createDepartmentDto, default);
                return RedirectToAction(nameof(DepartmentList));
            }
            else
            {
                ModelState.AddModelError("Title", "این دپارتمان قبلاً وجود دارد.");
                return RedirectToAction(nameof(CreateDepartment));
            }
            return View(createDepartmentDto);
        }
    }
}
