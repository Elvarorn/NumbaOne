using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud__.Models;
using Cloud__.Services;

namespace Cloud__.Controllers
{
    public class EditorController : Controller
    {
        // GET: Editor
        private FileService _fs;

        public EditorController()
        {
            _fs = new FileService();
        }

        public ActionResult AceEditor()
        {
            ViewBag.Code = "alert('Hello World');";
            ViewBag.DocumentID = 17; //Þurfum að breyta í ID-ið í gagnagrunninum, þetta er harðkóðað
            return View();
        }

        [HttpPost]
        public ActionResult SaveCode(EditorViewModel model)
        {
            string data = model.Content;
            System.Diagnostics.Debug.WriteLine("----SAVE data------");
            System.Diagnostics.Debug.WriteLine(model.Content);
            System.Diagnostics.Debug.WriteLine(data);

            _fs.SaveData(data);

            return View(RedirectToAction("AceEditor"));
        }
    }
}