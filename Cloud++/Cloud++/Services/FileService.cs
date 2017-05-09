using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cloud__.Models;
using Cloud__.Models.Entities;

namespace Cloud__.Services
{
    public class FileService
    {
        private ApplicationDbContext _db;

        public FileService()
        {
            _db = new ApplicationDbContext();
        }
        public void SaveData(string content)
        {
            System.Diagnostics.Debug.WriteLine("----DEBUG---");
            System.Diagnostics.Debug.WriteLine(content);
            File newFile = new File();
            newFile.content = content;
            newFile.fileName = "test";
            newFile.extension = "css";
            newFile.folderID = 1;

            _db.Files.Add(newFile);
            
            _db.SaveChanges();
        }

    }

   
}