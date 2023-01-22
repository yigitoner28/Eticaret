using Eticaret.Core.Dtos.Response;
using Eticaret.Core.Models;
using Eticaret.Core.Services;
using Eticaret.Web.Services;
using ETicaret.BussinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;


        //     private readonly ICategoryService _categoryService;

        public ProductController(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CustomResponseDto<List<Product>> customResponseDto = await _productApiService.GetListAsync();
            return View(customResponseDto.Data);
        }


        public async Task<IActionResult> Delete(int id)
        {
            bool sonuc = await _productApiService.DeleteByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            Product product = new Product();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product addProduct)
        {
          //  addProduct.ProductStatus = true;

            if (ModelState.IsValid)
            {

                var sonuc = await _productApiService.AddAsync(addProduct);
                if (sonuc.StatusCode == 200)
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(addProduct);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var sonuc = await _productApiService.GetModelByIdAsync(id);
            //List<bool> bools = new List<bool>() { true, false };
            //ViewBag.Status = new SelectList(bools,)

            return View(sonuc.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product updateProduct)
        {
            var sonuc = await _productApiService.UpdateAsync(updateProduct);
            return RedirectToAction(nameof(Index));
        }

    }



}
