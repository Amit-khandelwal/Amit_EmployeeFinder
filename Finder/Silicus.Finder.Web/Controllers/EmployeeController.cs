using AutoMapper;
using Silicus.Finder.Services.Interfaces;
using Silicus.Finder.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Silicus.Finder.Models.DataObjects;

namespace Silicus.Finder.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
            var emp = _employeeService.GetEmployee();
            return View(emp);
        }


        [HttpPost]
        public ActionResult SearchEmployeeByName(string name)
        {
            List<EmployeeNameViewModel> _employeeNameViewModel = new List<EmployeeNameViewModel>();
            if ( ModelState.IsValid)
            {
                var _employeeList = _employeeService.GetEmployeeByName(name);
                Mapper.Map(_employeeList, _employeeNameViewModel);
               
            }
            return View(_employeeNameViewModel);
        }
        public ActionResult Create()
        {
            var newEmployee = new Employee();
            return View(newEmployee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee newEmployee)
        {
            try
            {
                // TODO: Add insert logic here
                _employeeService.SaveEmployee(newEmployee);
                ViewBag.SavedEmployee = newEmployee.FirstName;
                return View("Success");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult AddProjectToEmployee()
        {
            var newEmployee = new Employee();
            return View(newEmployee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult AddProjectToEmployee(Employee newEmployee)
        {
            try
            {
                // TODO: Add insert logic here
                _employeeService.SaveEmployee(newEmployee);
                ViewBag.SavedEmployee = newEmployee.FirstName;
                return View("Success");
            }
            catch
            {
                return View();
            }

        }
        
    }
}
//name != null &&