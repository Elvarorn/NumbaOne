using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cloud__.Models;
using Cloud__.Models.Entities;
using Cloud__.Models.ViewModels;
using System.Data.Entity;

namespace Cloud__.Services
{
    public class FileService
    {
        private ApplicationDbContext _db;

        public FileService()
        {
            _db = new ApplicationDbContext();
        }

        public void CreateFile(CreateFileViewModel model, int projectid)
        {
            Project thisProject = _db.Projects.FirstOrDefault(x => x.ID == projectid);
            File newFile = new File();
            
            newFile.extension = model.FileType;
            newFile.fileName = model.FileName + model.FileType;
            newFile.content = "default robbatext";
            newFile.projectId = projectid;

            _db.Files.Add(newFile);
            _db.SaveChanges();

            thisProject.Files.Add(newFile);
            _db.SaveChanges();
        }

        public List<File> getFiles(int id)
        {
            int tempId = id;
            Project thisProject = _db.Projects.Include("Files").FirstOrDefault(x => x.ID == tempId);
            List<File> myFiles = new List<File>();
            var projectFiles = thisProject.Files.ToList<File>();
            foreach (File p in projectFiles)
            {
                if (_db.Entry(p).State == System.Data.Entity.EntityState.Detached)
                {
                    _db.Files.Attach(p);
                }
                thisProject.Files.Add(p);
                myFiles.Add(p);
            }

            return myFiles;
        }

        public void SaveData(string content, int pID)
        {
            File thisFile = _db.Files.FirstOrDefault(x => x.id == pID);
            thisFile.content = content;
            
            _db.SaveChanges();
        }

        public string getContent(int id)
        {
            File file = _db.Files.FirstOrDefault(x => x.id == id);

            return file.content;
        }

    }

   
}
