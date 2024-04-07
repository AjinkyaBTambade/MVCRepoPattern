using Core.Repositories.Interfaces;
using Core.Services.Interfaces;

using Core.Models;

namespace Core.Services;
public class EmployeeServices : IEmployeeService
{

    private readonly IEmployeeRepository _employeerepo;

    public EmployeeServices(IEmployeeRepository employeerepo)
    {
        _employeerepo = employeerepo;
    }


    public List<Employee> GetAllEmployees() => _employeerepo.GetAllEmployees();
    public Employee GetEmployeeById(int id) => _employeerepo.GetEmployeeById(id);
    public bool InsertEmployee(Employee emp) => _employeerepo.InsertEmployee(emp);
    public bool UpdateEmployee(Employee emp) => _employeerepo.UpdateEmployee(emp);

    public bool DeleteEmployee(int id) => _employeerepo.DeleteEmployee(id);
}
