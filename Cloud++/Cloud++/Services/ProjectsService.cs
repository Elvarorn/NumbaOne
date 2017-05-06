using Cloud__.Models;
using Cloud__.Models.Entities;
using System;
using System.Collections.Generic;
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

        public List<Project> getAllProjects(int userID) {
            // TODO: make viewmodel for this and use _db to make function work
            
            return null;
        }

        public Project getProjectByID(int projectID) {
            // TODO: make viewmodel and finish this function
            var project =_db.Projects.SingleOrDefault(x => x.ID == projectID);
            return project;
        }
    }
}