using Eticaret.Core.Dtos.Response;
using Eticaret.Core.Models;
using Eticaret.Core.Services;
using Eticaret.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicaret.BussinessLayer.Concrete
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {

        private readonly IEmployeeDal _employeeDal;

        public EmployeeService(IEmployeeDal employeeDal, IGenericDal<Employee> genericDal) : base(genericDal)
        {
            _employeeDal = employeeDal;
        }




    }
}
