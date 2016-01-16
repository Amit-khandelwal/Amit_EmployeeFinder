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
            ViewBag.Skills = new SelectList(_projectService.GetAllSkills(), "SkillSetId", "Name");
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        public ActionResult CreateProject(Project Project)
        {
            try
            {
                var skill = _projectService.GetSkillSetById(Project.skillSetId);
                Project.SkillSets.Add(skill); 

                var projectId = _projectService.AddProject(Project);
                if (projectId >= 0)
                {
                    TempData["AlertMessage"] = Project.ProjectName + " Having ProjectId: " + projectId + " Created Successfully.";

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
            var selectedEngagementManager = _projectService.GetEmployeeById(project.EngagementManagerId);
            var selectedProjectManager = _projectService.GetEmployeeById(project.ProjectManagerId);

            ViewBag.EngManager = new SelectList(_projectService.GetAllEmployee(), "EmployeeId", "FullName", selectedEngagementManager.EmployeeId);
            ViewBag.projManager = new SelectList(_projectService.GetAllEmployee(), "EmployeeId", "FullName", selectedProjectManager.EmployeeId);
            ViewBag.Technologies = new SelectList(_projectService.GetAllSkills(), "SkillSetId", "Name", project.skillSetId);

            return View(project);
        }

        [HttpPost]
        public ActionResult EditProject(Project Project)
        {
            var updatedProjectId =  _projectService.UpdateProject(Project);
            if (updatedProjectId >= 0)
            {
                TempData["AlertMessage"] = Project.ProjectName + " Having ProjectId: " + updatedProjectId+" Updated Successfully.";

            }
  
            return RedirectToAction("Index");
        }
    }
}
