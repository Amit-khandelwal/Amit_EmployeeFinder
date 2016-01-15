using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silicus.Finder.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: Projects
        public ActionResult Index()
        {
            var projects = _projectService.GetAllProjects();
            return View(projects);
        }

        // GET: Projects/Create
        public ActionResult CreateProject()
        {
            ViewBag.Employees = new SelectList(_projectService.GetAllEmployee(), "EmployeeId", "FullName");
            ViewBag.MultiEmployees = new MultiSelectList(_projectService.GetAllEmployee(), "EmployeeId", "FullName");

            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        public ActionResult CreateProject(Project Project)
        {
            try
            {

                //foreach(int employeeeId in Project.EmployeeIds)
                //{
                //    var tempEmployee=_projectService.GetEmployeeById(employeeeId);
                //    Project.Employees.Add(tempEmployee);
                //}

                var projectId = _projectService.Add(Project);
                if (projectId >= 0)
                {
                    TempData["AlertMessage"] = Project.ProjectName + " created successfully..ProjectId:" + projectId;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditProject(int? id)
        {
            var project = _projectService.GetProjectById(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            _projectService.Add(project);
            return View(project);
        }
    }
}
