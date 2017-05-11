using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cloud__.Models.ViewModels
{

        public class InviteUserViewModel
        {
            [Required]
            [Display(Name = "Username :")]
            public string Username { get; set; }

            public string Type { get; set; }
            public int projectID { get; set; }
        }
}