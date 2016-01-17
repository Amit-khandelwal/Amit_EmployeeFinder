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

        [HttpPost]
        public ActionResult SearchEmployeeByName(string name)
        {
            List<EmployeesListViewModel> employeesListViewModel = new List<EmployeesListViewModel>();
            if (ModelState.IsValid)
            {
                var employeeList = _employeeService.GetEmployeeByName(name);
                Mapper.Map(employeeList, employeesListViewModel);

            }

            if (employeesListViewModel.Count != 0)
            {
                return View("Index", employeesListViewModel);
            }
            else
            {
                ViewBag.current = "Incorrect Employee Name! Please refine your search.";
                return View("NoEmployee");
            }

        }


        public ActionResult Index()
        {
            var employeesList = _employeeService.GetAllEmployees();
            var employeesListViewModel = new List<EmployeesListViewModel>();
            Mapper.Map(employeesList, employeesListViewModel);
            return View(employeesListViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var newEmployee = new Employee();
            ViewBag.Projects = new MultiSelectList(_employeeService.GetAllProjects(), "ProjectId", "ProjectName");
            ViewBag.Skills = new MultiSelectList(_employeeService.GetAllSkillSets(), "SkillSetId", "Name");
            return View(newEmployee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee newEmployee)
        {
            try
            {
                // TODO: Add insert logic here
                if (newEmployee.ProjectId != null)
                {
                    foreach (int projectId in newEmployee.ProjectId)
                    {
                        var employeeProject = _employeeService.GetProjectById(projectId);
                        newEmployee.Projects.Add(employeeProject);
                    }
                }
                if (newEmployee.SkillId != null)
                {
                    foreach (int skillId in newEmployee.SkillId)
                    {
                        var employeeSkill = _employeeService.GetSkillSetById(skillId);
                        newEmployee.SkillSets.Add(employeeSkill);
                    }
                }

                _employeeService.SaveEmployee(newEmployee);
                ViewBag.SavedEmployee = newEmployee.FirstName;
                return View("Success");
            }
            catch
            {
                return View();
            }

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var selectedEmployee = _employeeService.GetEmployeeById(id);
            ViewBag.Projects = new MultiSelectList(_employeeService.GetAllProjects(), "ProjectId", "ProjectName");
            ViewBag.Skills = new MultiSelectList(_employeeService.GetAllSkillSets(), "SkillSetId", "Name");
            return View(selectedEmployee);
        }

        // POST: Employee/Edit
        [HttpPost]
        public ActionResult Edit(Employee selectedEmployee)
        {
            ViewBag.Projects = new MultiSelectList(_employeeService.GetAllProjects(), "ProjectId", "ProjectName");
            ViewBag.Skills = new MultiSelectList(_employeeService.GetAllSkillSets(), "SkillSetId", "Name");
            try
            {
                if (selectedEmployee.ProjectId != null)
                {
                    foreach (int projectId in selectedEmployee.ProjectId)
                    {
                        var employeeProject = _employeeService.GetProjectById(projectId);
                        selectedEmployee.Projects.Add(employeeProject);
                    }
                }
                if (selectedEmployee.SkillId != null)
                {
                    foreach (int skillId in selectedEmployee.SkillId)
                    {
                        var employeeSkill = _employeeService.GetSkillSetById(skillId);
                        selectedEmployee.SkillSets.Add(employeeSkill);
                    }
                }
                _employeeService.EditEmployee(selectedEmployee);
                return View("Success");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            var selectedEmployee = _employeeService.GetEmployeeById(id);
            var employeeViewModel = new EmployeeViewModel();
            Mapper.Map(selectedEmployee, employeeViewModel);
            return View(employeeViewModel);

        }

    }
}