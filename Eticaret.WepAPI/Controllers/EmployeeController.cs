using Eticaret.Core.Models;
using Eticaret.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eticaret.WepAPI.Controllers
{

    public class EmployeeController : CustomBaseController
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            return CreateActionResult(await _employeeService.GetListAsync());
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _employeeService.GetModelByIdAsync(id));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] Employee employee)
        {
            return CreateActionResult(await _employeeService.AddAsync(employee));
        }


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            return CreateActionResult(await _employeeService.UpdateAsync(employee));
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _employeeService.DeleteByIdAsync(id));
        }
    }
}

