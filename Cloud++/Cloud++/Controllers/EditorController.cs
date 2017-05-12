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
using Cloud__.Models.Entities;
using System.Data.Entity;

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

        public ActionResult ListFiles()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string userid = User.Identity.GetUserId();
            int tempId = (int)TempData["id"];
            Project thisProject = db.Projects.Include("Files").FirstOrDefault(x => x.ID == tempId);
            List<File> myFiles = new List<File>();
            var projectFiles = thisProject.Files.ToList<File>();
            foreach (File p in projectFiles)
            {
                if (db.Entry(p).State == System.Data.Entity.EntityState.Detached)
                {
                    db.Files.Attach(p);
                }
                thisProject.Files.Add(p);
                myFiles.Add(p);
            }
            ViewBag.MyList = myFiles;
            return View(myFiles);
        }

        public ActionResult AceEditor(int id)
        {
            EditorViewModel model = new EditorViewModel();

            model.FileID = id;
            model.ProjectID = _ps.getProjectID(id);

            List<File> files = _fs.getFiles(model.ProjectID);
            model.Files = files;

            TempData["id"] = model.ProjectID;
            TempData["fileid"] = model.FileID;
            
            ViewBag.Code = _fs.getContent(model.FileID);
            ViewBag.DocumentID = id;            

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateFile(CreateFileViewModel model)
        {
            int projectid = (int)TempData["id"];
            ViewBag.DocumentID = TempData["fileid"];
            _fs.CreateFile(model, projectid);

            return RedirectToAction("AceEditor", "Editor", new { id = TempData["fileid"] });
       
        }

        [HttpPost]
        public JsonResult SaveCodeAjax(EditorViewModel model)
        {
            string data = model.Content;
            _fs.SaveData(data, (int)TempData["fileid"]);

            return Json("Success");
        }

        [HttpPost]
        public ActionResult Invite(InviteUserViewModel model)
        {
            int theID = (int)TempData["id"];
            _ps.Invite(model.Username, theID);
            return RedirectToAction("AceEditor", "Editor", new { id = TempData["fileid"] });
        }

    }
}
