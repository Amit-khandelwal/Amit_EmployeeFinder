using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;

namespace Silicus.Finder.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
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
            ViewBag.Employees2 = new MultiSelectList(_projectService.GetAllEmployee(), "EmployeeId", "FullName");

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
                    TempData["AlertMessage"] = Project.ProjectName + "created successfully..ProjectId:" + projectId;

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
