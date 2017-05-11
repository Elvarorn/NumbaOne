using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud__.Models;
using Cloud__.Services;
using System.Web.ApplicationServices;
using Cloud__.Models.ViewModels;
using Microsoft.AspNet.Identity;

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

        public ActionResult AceEditor(int id)
        {
            if(id != null)
            {
                ViewBag.Code = _fs.getContent(id);
                ViewBag.DocumentID = id;
            }
            else
            {
                ViewBag.Code = "ble";
                ViewBag.DocumentID = 7;
            }
            

            

            return View();
        }

        [HttpPost]
        public ActionResult CreateFile(CreateFileViewModel model)
        {
            string username = User.Identity.GetUserName();
            _fs.CreateFile(model, username);

            return RedirectToAction("AceEditor", "Editor");
        }

        [HttpPost]
        public JsonResult SaveCodeAjax(EditorViewModel model)
        {
            string data = model.Content;
            int fileId = model.FileID;
            
            _fs.SaveData(data, fileId);

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
