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
            return View();
        }

        // GET: Projects/Create
        public ActionResult CreateProject()
        {
            ViewBag.Employees = new SelectList(_projectService.GetAllEmployee(), "EmployeeId", "FullName");
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        public ActionResult CreateProject(Project Project)
        {
            try
            {
                var projectId = _projectService.Add(Project);
                if (projectId != null)
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
    }
}
