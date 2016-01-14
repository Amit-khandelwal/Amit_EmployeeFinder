﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;
using AutoMapper;
using Silicus.Finder.Web.ViewModel;

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

        public ActionResult Details(int employeeId)
        {
            var newEmployee = _employeeService.GetEmployee(employeeId);
            var employeeDetails = new EmployeeViewModel();
            Mapper.Map(newEmployee, employeeDetails);
            return View(employeeDetails);
        }

        public ActionResult Edit(int employeeId)
        {
            _employeeService.GetEmployee(1);
            var newEmployee = new Employee();
            var employeeDetails = new EmployeeViewModel();
            Mapper.Map(newEmployee, employeeDetails);
            return View("EmployeeDetails", newEmployee);
        }
    }
}