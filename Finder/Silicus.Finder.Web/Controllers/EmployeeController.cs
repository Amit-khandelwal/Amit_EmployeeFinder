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
            List<EmployeeNameViewModel> employeeNameViewModel = new List<EmployeeNameViewModel>();
            if (ModelState.IsValid)
            {
                var employeeList = _employeeService.GetEmployeeByName(name);
                Mapper.Map(employeeList, employeeNameViewModel);

            }

            if (employeeNameViewModel.Count != 0)
            {
                return View(employeeNameViewModel);
            }
            else
            {
                ViewBag.current = "Incorrect Employee Name! Please refine your search.";
                return View("NoEmployee");
            }

        }


        public ActionResult GetEmployeesList()
        {
            var employeesList = _employeeService.GetEmployee();
            var employeesListViewMode = new List<EmployeesListViewMode>();
            Mapper.Map(employeesList, employeesListViewMode);
            return View(employeesListViewMode);
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
