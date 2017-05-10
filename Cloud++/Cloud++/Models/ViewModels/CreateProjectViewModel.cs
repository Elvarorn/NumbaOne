using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cloud__.Models.ViewModels
{
    public class CreateProjectViewModel
    {
        [Required]
        [Display(Name = "Project name  :")]
        public string Name { get; set; }

        public string Type { get; set; }
        public int projectID { get; set; }
    }
}