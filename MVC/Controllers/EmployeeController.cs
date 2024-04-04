using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCLIB.Models;
using MVC.Models;
using MVCLIB.Services.Interfaces;


namespace MVC.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService  _employeeservice;

    public EmployeeController(IEmployeeService employeeservice)
    {
        _employeeservice = employeeservice;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult ShowAll()
    {

        ViewData["allemployees"] = _employeeservice.GetAllEmployees();
        return View();
    }
[HttpGet]
    public IActionResult ShowById()
    {
        return View();
    }

[HttpGet]
    public IActionResult Search()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Search(int id)
    {
        var employee =_employeeservice.GetEmployeeById(id);
        return View("ShowById", employee);
    }



    [HttpGet]
    public IActionResult Insert()
    {

        Employee employee=null ;
        return View(employee);

    }

    [HttpPost]
    public IActionResult Insert(Employee employee)
    {

       _employeeservice.InsertEmployee(employee);

        return RedirectToAction("ShowAll", "Employee");
    }



    [HttpGet]
    public IActionResult Update(int id)
    {
       var employee =_employeeservice.GetEmployeeById(id);
        return View(employee);
    }
    [HttpPost]
    public IActionResult Update(Employee employee)
    {
       _employeeservice.UpdateEmployee(employee);
        return RedirectToAction("ShowAll", "Employee");
    }


    [HttpGet]
    public IActionResult Delete(int id)
    {
        var employee =_employeeservice.GetEmployeeById(id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Delete(Employee employee)
    {
        _employeeservice.DeleteEmployee(employee.Id);
        return RedirectToAction("ShowAll", "Employee");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
