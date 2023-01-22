using Eticaret.Core.Dtos.Response;
using Eticaret.Core.Models;
using Eticaret.Core.Services;
using Eticaret.Web.Services;
using ETicaret.BussinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeApiService _employeeApiService;


        //     private readonly ICategoryService _categoryService;

        public EmployeeController(EmployeeApiService employeeApiService)
        {
            _employeeApiService = employeeApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CustomResponseDto<List<Employee>> customResponseDto = await _employeeApiService.GetListAsync();
            return View(customResponseDto.Data);
        }


        public async Task<IActionResult> Delete(int id)
        {
            bool sonuc = await _employeeApiService.DeleteByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            Employee employee = new Employee();

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee addEmployee)
        {
            //addEmployee.CategoryStatus = true;

            if (ModelState.IsValid)
            {

                var sonuc = await _employeeApiService.AddAsync(addEmployee);
                if (sonuc.StatusCode == 200)
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(addEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var sonuc = await _employeeApiService.GetModelByIdAsync(id);
            //List<bool> bools = new List<bool>() { true, false };
            //ViewBag.Status = new SelectList(bools,)

            return View(sonuc.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee updateEmployee)
        {
            var sonuc = await _employeeApiService.UpdateAsync(updateEmployee);
            return RedirectToAction(nameof(Index));
        }

    }



}
