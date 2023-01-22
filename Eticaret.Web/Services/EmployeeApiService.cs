using Eticaret.Core.Dtos.Response;
using Eticaret.Core.Models;
using Eticaret.Core.Services;
using System.Linq.Expressions;

namespace Eticaret.Web.Services
{
    public class EmployeeApiService
    {

        private readonly HttpClient _httpClient;
        public EmployeeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomResponseDto<Employee>> AddAsync(Employee entity)
        {
            var response = await _httpClient.PostAsJsonAsync("Employee/Add", entity);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<Employee>>();

            return responseBody;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Employee/Delete/{id}");

            return response.IsSuccessStatusCode;
        }

        public Task<CustomResponseDto<List<Employee>>> Get3EmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<Employee>> GetAsync(Expression<Func<Employee, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<List<Employee>>> GetListAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<Employee>>>("Employee/GetList");

            return response;
        }

        public async Task<CustomResponseDto<Employee>> GetModelByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<Employee>>($"Employee/GetById/{id}");

            return response;
        }

        public async Task<bool> UpdateAsync(Employee entity)
        {
            var response = await _httpClient.PutAsJsonAsync("Employee/Update", entity);

            return response.IsSuccessStatusCode;
        }
    }
}
