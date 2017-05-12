using Cloud__.Models;
using Cloud__.Models.Entities;
using Cloud__.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cloud__.Services
{
    public class ProjectsService 
    {
        private ApplicationDbContext _db;

        public DbSet<Project> Projects { get; set; }

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
            newFile.content = "default text by robbi";

            newProject.Name = model.Name;

            ApplicationUser user = _db.Users.FirstOrDefault(x => x.UserName == username);

            _db.Files.Add(newFile);
            _db.Projects.Add(newProject);
            _db.SaveChanges();

            newProject.Files.Add(newFile);
            newProject.Users.Add(user);
            user.Projects.Add(newProject);
            _db.SaveChanges();
        }

        public List<Project> getAllProjects(string userid) {

            ApplicationUser currentUser = _db.Users.Include("Projects").FirstOrDefault(x => x.Id == userid);

            List<Project> myProjects = new List<Project>();
            var userProjects = currentUser.Projects.ToList<Project>();

            foreach (Project p in userProjects)
            {
                if (_db.Entry(p).State == System.Data.Entity.EntityState.Detached)
                {
                    _db.Projects.Attach(p);
                }

                currentUser.Projects.Add(p);
                myProjects.Add(p);
            }

            return myProjects;
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

        public int getProjectID(int fileID)
        {
            File thisFile = _db.Files.FirstOrDefault(x => x.id == fileID);

            int projectid = thisFile.projectId;

            return projectid;
        }

        public void Invite(string username, int projectid)
        {
            
            Project thisProject = _db.Projects.FirstOrDefault(x => x.ID == projectid);
            ApplicationUser thisUser = _db.Users.FirstOrDefault(x => x.UserName == username);

            if (thisProject != null && thisUser != null)
            {
                thisProject.Users.Add(thisUser);
                thisUser.Projects.Add(thisProject);
                _db.SaveChanges();
            }
        }


    }
}