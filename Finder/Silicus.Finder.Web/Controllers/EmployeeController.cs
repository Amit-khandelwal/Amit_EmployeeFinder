using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;

namespace Silicus.Finder.Web.Controllers
{
    public class EmployeeController : Controller
    {
         private readonly IEmployeeService _employeeService;

         public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var newEmployee = new Employee();
            return View("CreateEmployee", newEmployee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee newEmployee)
        {
            try
            {
                // TODO: Add insert logic here
                _employeeService.SaveEmployee(newEmployee);
                return View("Success");
            }
            catch
            {
                return View();
            }
            
        }
    }
}