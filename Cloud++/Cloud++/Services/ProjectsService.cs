using Cloud__.Models;
using Cloud__.Models.Entities;
using Cloud__.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Cloud__.Services
{
    public class ProjectsService
    {
        private ApplicationDbContext _db;

        //constructor sem býr til tengingu við gagnagrunn
        public ProjectsService() {
            _db = new ApplicationDbContext();
        }

        public void CreateProject(CreateProjectViewModel model, string username)
        {
            Project newProject = new Project();
            File newFile = new File();

            newFile.extension = model.Type;
            newFile.fileName = model.Name + newFile.extension;

            newProject.Name = model.Name;

            ApplicationUser user = _db.Users.FirstOrDefault(x => x.UserName == username);

            _db.Files.Add(newFile);
            _db.Projects.Add(newProject);
            _db.SaveChanges();

            newProject.Users.Add(user);
            user.Projects.Add(newProject);
            _db.SaveChanges();
        }

        public List<Project> getAllProjects(int userID) {
            // TODO: make viewmodel for this and use _db to make function work
            
            return null;
        }

        internal void InviteUser(InviteUserViewModel model, string username)
        {
            throw new NotImplementedException();
        }

        public Project getProjectByID(int projectID) {
            // TODO: make viewmodel and finish this function
            var project =_db.Projects.SingleOrDefault(x => x.ID == projectID);
            return project;
        }


    }
}