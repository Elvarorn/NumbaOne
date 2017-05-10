using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Cloud__.Models;
using Cloud__.Models.ViewModels;
using System.Threading.Tasks;
using Cloud__.Models.Entities;
using Cloud__.Services;

namespace Cloud__.Controllers
{
    public class HomeController : Controller
    {
        private ProjectsService _ps = new ProjectsService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProjectViewModel model)
        {

            _ps.CreateProject(model);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
         
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Code = "alert('Hello World');";
            ViewBag.DocumentID = 17; //Þurfum að breyta í ID-ið í gagnagrunninum, þetta er harðkóðað

            return View();
        }

        public ActionResult Tutorials()
        {
            return View();
        }
    }
}