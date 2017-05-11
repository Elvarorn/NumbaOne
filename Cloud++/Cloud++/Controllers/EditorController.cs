using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud__.Models;
using Cloud__.Services;
using System.Web.ApplicationServices;
using Cloud__.Models.ViewModels;

namespace Cloud__.Controllers
{
    public class EditorController : Controller
    {
        // GET: Editor
        private FileService _fs;
        private ProjectsService _ps;


        public EditorController()
        {
            _fs = new FileService();
            _ps = new ProjectsService();
        }

        public ActionResult AceEditor()
        {
            ViewBag.Code = "alert('Hello World');";
            ViewBag.DocumentID = 17; //Þurfum að breyta í ID-ið í gagnagrunninum, þetta er harðkóðað
            return View();
        }

        [HttpPost]
        public JsonResult SaveCodeAjax(EditorViewModel model)
        {
            string data = model.Content;


            _fs.SaveData(data);

            return Json("Success");
        }

        [HttpPost]
        public ActionResult Invite(InviteUserViewModel model)
        {
            string username = model.Username;
            
            _ps.Invite(username, 3);
            return RedirectToAction("AceEditor", "Editor");
        }

    }
}
