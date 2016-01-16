using AutoMapper;
using Silicus.Finder.Services.Interfaces;
using Silicus.Finder.Web.ViewModel;
using System;
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
            var emp = _employeeService.GetAllEmployees();
            return View(emp);
        }


        [HttpPost]
        public ActionResult SearchEmployeeByName(string name)
        {
            List<EmployeeNameViewModel> _employeeNameViewModel = new List<EmployeeNameViewModel>();
            if (ModelState.IsValid)
            {
                var _employeeList = _employeeService.GetEmployeeByName(name);
                Mapper.Map(_employeeList, _employeeNameViewModel);

            }
            return View(_employeeNameViewModel);
        }

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

                foreach (int projectId in newEmployee.ProjectId)
                {
                    var employeeProject = _employeeService.GetProjectById(projectId);
                    newEmployee.Projects.Add(employeeProject);
                }

                foreach (int skillId in newEmployee.SkillId)
                {
                    var employeeSkill = _employeeService.GetSkillSetById(skillId);
                    newEmployee.SkillSets.Add(employeeSkill);
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

        public ActionResult Edit(int id)
        {
            var selectedEmployee = _employeeService.GetEmployeeById(id);
            return View(selectedEmployee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Edit(Employee selectedEmployee)
        {
            try
            {
                _employeeService.EditEmployee(selectedEmployee);
                return View("Success");
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult AddSkillSetToEmployee(EmployeeSkillSet newEmployeeSkillSet)
        {
            try
            {
                _employeeService.SaveEmployeeSkillSet(newEmployeeSkillSet);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return View(employee);
        }

    }

}
