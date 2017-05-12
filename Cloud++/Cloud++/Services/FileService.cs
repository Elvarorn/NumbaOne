using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cloud__.Models;
using Cloud__.Models.Entities;
using Cloud__.Models.ViewModels;

namespace Cloud__.Services
{
    public class FileService
    {
        private ApplicationDbContext _db;

        public FileService()
        {
            _db = new ApplicationDbContext();
        }

        public void CreateFile(CreateFileViewModel model, string username)
        {
            Project newProject = new Project();
            File newFile = new File();

            newFile.extension = model.FileType;
            newFile.fileName = model.FileName + model.FileType;

            newProject.Name = newProject.Name;

            ApplicationUser user = _db.Users.FirstOrDefault(x => x.UserName == username);

            _db.Files.Add(newFile);
            _db.Projects.Add(newProject);
            _db.SaveChanges();

            newProject.Users.Add(user);
            user.Projects.Add(newProject);
            _db.SaveChanges();
        }

        public void SaveData(string content, int pID)
        {
            File thisFile = _db.Files.FirstOrDefault(x => x.id == pID);
            thisFile.content = content;
            
            _db.SaveChanges();
        }

        public string getContent(int id)
        {
            Project currentProject = _db.Projects.FirstOrDefault(x => x.ID == id);

            

            File file = _db.Files.FirstOrDefault(x => x.id == id);
            return file.content;
        }

    }

   
}
