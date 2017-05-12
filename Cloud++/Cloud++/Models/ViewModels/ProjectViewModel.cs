using Cloud__.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud__.Models.ViewModels
{
    public class ProjectViewModel
    {
        public List<Project> Projects { get; set; }
        public int fileID { get; set; }
    }
}