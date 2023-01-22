using Eticaret.Core.Dtos.Response;
using Eticaret.Core.Models;
using Eticaret.Core.Services;
using System.Linq.Expressions;

namespace Eticaret.Web.Services
{
    public class ProductApiService
    {

        private readonly HttpClient _httpClient;
        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomResponseDto<Product>> AddAsync(Product entity)
        {
            var response = await _httpClient.PostAsJsonAsync("Product/Add", entity);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<Product>>();

            return responseBody;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Product/Delete/{id}");

            return response.IsSuccessStatusCode;
        }

        public Task<CustomResponseDto<List<Product>>> Get3ProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<Product>> GetAsync(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<List<Product>>> GetListAsync(Expression<Func<Product, bool>> filter = null)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<Product>>>("Product/GetList");

            return response;
        }

        public async Task<CustomResponseDto<Product>> GetModelByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<Product>>($"Product/GetById/{id}");

            return response;
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            var response = await _httpClient.PutAsJsonAsync("Product/Update", entity);

            return response.IsSuccessStatusCode;
        }
    }
}
