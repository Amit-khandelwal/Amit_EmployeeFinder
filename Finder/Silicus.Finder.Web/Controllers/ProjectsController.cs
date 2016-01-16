using AutoMapper;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;
using Silicus.Finder.Web.ViewModel;
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
        
    
        public ActionResult GetProjectList(string name)
        {
            IEnumerable<Project> projectList;

            if(name != "")
            {
                projectList = _projectService.GetProjectsListByName(name);
                
                if(projectList.Count() == 0)
                {
                    ViewBag.Message = "Incorrect Project Name! Please refine your search.";
                    return View("ProjectNotFound");
                }
            }
            else
            {
                projectList = _projectService.GetProjectsList();
            }

            List<ProjectListViewModel> projectListViewModel = new List<ProjectListViewModel>();
            Mapper.Map(projectList, projectListViewModel);

            return View("ProjectList", projectListViewModel);
        }

        [HttpGet]
        public ActionResult EditProject(int? id)
        {
            var project = _projectService.GetProjectById(id);
            var selectedEngagementManager = _projectService.GetEmployeeById(project.EngagementManagerId);
            var selectedProjectManager = _projectService.GetEmployeeById(project.ProjectManagerId);

            ViewBag.EngManager = new SelectList(_projectService.GetAllEmployee(), "EmployeeId", "FullName", selectedEngagementManager.EmployeeId);
            ViewBag.projManager = new SelectList(_projectService.GetAllEmployee(), "EmployeeId", "FullName", selectedProjectManager.EmployeeId);
           
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
