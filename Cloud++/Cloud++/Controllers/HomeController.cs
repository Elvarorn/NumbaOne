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
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Cloud__.Controllers
{
    public class HomeController : Controller
    {
        private ProjectsService _ps = new ProjectsService();

        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            string userid = User.Identity.GetUserId();

            ApplicationUser currentUser = db.Users.Include("Projects").FirstOrDefault(x => x.Id == userid);

            List<Project> myProjects = new List<Project>();
            var userProjects = currentUser.Projects.ToList<Project>();

            foreach (Project p in userProjects)
            {
                if (db.Entry(p).State == System.Data.Entity.EntityState.Detached)
                {
                    db.Projects.Attach(p);
                }

                currentUser.Projects.Add(p);
                myProjects.Add(p);
            }

            //foreach (var projectss in currentUser.Projects)
            //{
            //    myProjects.Add(projectss);
            //}


            return View(myProjects);
        }

		public JsonResult GetAllProjects()
		{
			List<Project> allProjects = new List<Project>();

			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				allProjects = db.Projects.ToList();
			}

			return new JsonResult { Data = allProjects, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		[HttpPost]
        public ActionResult Create(CreateProjectViewModel model)
        {
            string username = User.Identity.GetUserName();
            _ps.CreateProject(model, username);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Invite(InviteUserViewModel model)
        {
            string username = User.Identity.GetUserName();
            _ps.InviteUser(model, username);

            return View("AceEditor");
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
