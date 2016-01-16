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
    public class TechnologyController : Controller
    {
        private readonly ISkillSetService _skillSetService;

        public TechnologyController(ISkillSetService skillSetService)
        {
            _skillSetService = skillSetService;
        }
        // GET: Technology
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var skillset = new SkillSet();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SkillSet skillSet)
        {
            _skillSetService.Add(skillSet);
            ViewBag.SavedskillSet = skillSet.Name;
            return View("Success");
        }
    }
}