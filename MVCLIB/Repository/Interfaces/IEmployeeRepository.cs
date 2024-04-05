using MVCLIB.Models;
using System.Collections.Generic;
using System.Text;

namespace MVCLIB.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
         bool InsertEmployee(Employee emp);
         bool UpdateEmployee(Employee emp);

         bool DeleteEmployee(int id);
    }
}
