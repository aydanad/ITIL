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
        public async Task<IActionResult> RemoveCity(Guid id, int departmentCount)
        {
            if (departmentCount == 0)
            {
                if (await _cityService.RemoveAsync(id, default))
                {
                    return RedirectToAction(nameof(CityList));
                }
            }
            else
            {
                TempData["ErrorMessage"] = "برای این شهر دپارتمان وجود دارد.";
                return RedirectToAction(nameof(CityList));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCity(Guid id)
        {
            var city = await _cityService.GetAsync(id);
            if (city == null) return NotFound();
            var updateDto = new UpdateCityDto
            {
                Id = city.Id,
                Title = city.Title
            };
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCity(UpdateCityDto cityDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _cityService.UpdateAsync(cityDto, default);
                    if (result)
                    {
                        return RedirectToAction(nameof(CityList));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(nameof(UpdateCityDto.Title), ex.Message);
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
                bool cityExists = await _cityService.ExistsAsync(createCityDto.Title);
                if (cityExists)
                {
                    TempData["ErrorMessage"] = "این شهر وجود دارد.";
                    return RedirectToAction(nameof(CreateCity));
                }
                await _cityService.InsertAsync(createCityDto, default);
                return RedirectToAction(nameof(CityList));
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
                if (await _departmentServices.RemoveAsync(id, default))
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
            var cities = await _cityService.GetAllAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Title");
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
            //ViewBag.Cities = cities.Select(t => new SelectListItem(t.Title,t.Id+string.Empty));
            ViewBag.Cities =new SelectList( cities, "Id" ,"Title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            if (ModelState.IsValid)
            {
                bool departmentExists = await _departmentServices.ExistsAsync(createDepartmentDto.Title, createDepartmentDto.CityId, createDepartmentDto.DepartmentType);
                if (departmentExists)
                {
                    TempData["ErrorMessage"] = "این دپارتمان قبلاً وجود دارد.";
                    return RedirectToAction(nameof(CreateDepartment));

                }
                await _departmentServices.InsertAsync(createDepartmentDto, default);
                return RedirectToAction(nameof(DepartmentList));
            }
            return View(createDepartmentDto);
        }







        public async Task<IActionResult> PersonList()
        {
            var people = await _personService.GetAllAsync();
            return View(people);
        }
        [HttpGet]
        public async Task<IActionResult> RemovePerson(Guid id)
        {
                if (await _personService.RemoveAsync(id, default))
                {
                    return RedirectToAction(nameof(PersonList));
                }

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePerson(Guid id)
        {
            var person = await _personService.GetAsync(id);
            if (person == null) return NotFound();
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerson(UpdatePersonDto updatePersonDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _personService.UpdateAsync(updatePersonDto, default);
                if (result)
                {
                    return RedirectToAction(nameof(PersonList));
                }
            }
            return View(updatePersonDto);
        }
        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonDto createPersonDto)
        {
            if (ModelState.IsValid)
            {
                bool personExists = await _personService.ExistsAsync(createPersonDto.NationalCode);
                if (personExists)
                {
                    TempData["ErrorMessage"] = "این شخص وجود دارد.";
                    return RedirectToAction(nameof(CreatePerson));
                }
                await _personService.InsertAsync(createPersonDto, default);
                return RedirectToAction(nameof(PersonList));
            }
            return View(createPersonDto);
        }
        public IActionResult PersonDepartmentList()
        {
            return View();
        }

    }
}
