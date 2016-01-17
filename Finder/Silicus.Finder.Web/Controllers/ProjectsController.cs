﻿using AutoMapper;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;
using Silicus.Finder.Web.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace Silicus.Finder.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private int _pageSize = 10;
        private int _pageNumber;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: Projects
        public ActionResult Index()
        {
            //var projects = _projectService.GetAllProjects();
            return View();
        }

        // GET: Projects/Create
        public ActionResult CreateProject()
        {
            ViewBag.Employees = new SelectList(_projectService.GetAllEmployees(), "EmployeeId", "FullName");
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

                return RedirectToAction("GetProjectList");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult GetProjectList(int? page)
        {
            _pageNumber = (page ?? 1);

            ViewData["Employees"] = _projectService.GetAllEmployees();
            var projectList = _projectService.GetProjectsList();
               
            List<ProjectListViewModel> projectListViewModel = new List<ProjectListViewModel>();
            Mapper.Map(projectList, projectListViewModel);

            return View("ProjectList", projectListViewModel.ToPagedList(_pageNumber, _pageSize));
        }

        public ActionResult GetProjectsListByName(string name, int? page)
        {
            IEnumerable<Project> projectList;
            _pageNumber = (page ?? 1);

            ViewData["Employees"] = _projectService.GetAllEmployees();
            ViewData["name"] = name;

            ViewBag.Message = "Incorrect Project Name! Please refine your search.";

            projectList = _projectService.GetProjectsListByName(name);

            if (projectList.Count() == 0)
            {
                return View("ProjectNotFound");
            }
            
            List<ProjectListViewModel> projectListViewModel = new List<ProjectListViewModel>();
            Mapper.Map(projectList, projectListViewModel);

            return View("ProjectList", projectListViewModel.ToPagedList(_pageNumber,_pageSize));
        }

        [HttpGet]
        public ActionResult EditProject(int? id)
        {
            var project = _projectService.GetProjectById(id);
            var selectedEngagementManager = _projectService.GetEmployeeById(project.EngagementManagerId);
            var selectedProjectManager = _projectService.GetEmployeeById(project.ProjectManagerId);

            ViewBag.EngManager = new SelectList(_projectService.GetAllEmployees(), "EmployeeId", "FullName", selectedEngagementManager.EmployeeId);
            ViewBag.projManager = new SelectList(_projectService.GetAllEmployees(), "EmployeeId", "FullName", selectedProjectManager.EmployeeId);
            ViewBag.Technologies = new SelectList(_projectService.GetAllSkills(), "SkillSetId", "Name", project.skillSetId);
           
            return View(project);
        }

        [HttpPost]
        public ActionResult EditProject(Project Project)
        {
            var updatedProjectId = _projectService.UpdateProject(Project);
            if (updatedProjectId >= 0)
            {
                TempData["AlertMessage"] = Project.ProjectName + " Having ProjectId: " + updatedProjectId + " Updated Successfully.";

            }

            return RedirectToAction("GetProjectList");
        }


        [HttpGet]
        public ActionResult AddEmployeeToProject(int id)
        {
            var employeeList = _projectService.GetAllEmployee();
            ViewBag.ProjectId = id;
            return View(employeeList);
        }

         [HttpGet]
        public ActionResult RemoveProjectEmployee(int empId, int projectId)
        {
            var isRemoved = _projectService.DeallocateEmployyeFromProject(empId, projectId);
            return RedirectToAction("EditProject", new { id = projectId });
        }


     
    }
}
