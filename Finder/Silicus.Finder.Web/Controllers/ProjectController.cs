using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;
using System.Collections.Generic;
using Silicus.Finder.Web.ViewModel;
using AutoMapper;

namespace Silicus.Finder.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectDetailService _projectDetailService;
        private readonly IProjectService _projectService;

        public ProjectController(IProjectDetailService projectDetailService, IProjectService projectService)
        {
            _projectDetailService = projectDetailService;
            _projectService = projectService;
        }

        public ActionResult GetProjectDetails([DataSourceRequest] DataSourceRequest request)
        {
            var projectDetails = _projectDetailService.GetProjectDetails();
            return Json(projectDetails.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateProject(ProjectDetail projectDetail)
        {
            if (projectDetail != null && ModelState.IsValid)
            {
                return Json(_projectDetailService.Add(projectDetail));
            }

            return Json(-1);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateProject(ProjectDetail projectDetail)
        {
            if (projectDetail != null && ModelState.IsValid)
            {
                _projectDetailService.Update(projectDetail);
                return Json(1);
            }

            return Json(-1);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteProject(ProjectDetail projectDetail)
        {
            if (projectDetail != null && ModelState.IsValid)
            {
                _projectDetailService.Delete(projectDetail);
                return Json(1);
            }

            return Json(-1);
        }

        public ActionResult GetProjectList([Bind(Include = "Employees")] Project project)
        {
            var projectList = _projectService.GetProjectsList();
            List<ProjectListViewModel> projectListViewModel = new List<ProjectListViewModel>();
            Mapper.Map(projectList,projectListViewModel);
            return View("ProjectList", projectListViewModel);
        }
    }
}
