using Eticaret.Core.Models;
using Eticaret.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eticaret.WepAPI.Controllers
{

    public class ProductController : CustomBaseController
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            return CreateActionResult(await _productService.GetListAsync());
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _productService.GetModelByIdAsync(id));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            return CreateActionResult(await _productService.AddAsync(product));
        }


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            return CreateActionResult(await _productService.UpdateAsync(product));
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _productService.DeleteByIdAsync(id));
        }
    }
}
