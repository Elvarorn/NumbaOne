using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cloud__.Models.ViewModels
{
    public class CreateFileViewModel
    {
        [Required]
        [Display(Name = "File name :")]
        public string FileName { get; set; }

        [Required]
        [Display(Name = "File extension :")]
        public string FileType { get; set; }
        public int projectID { get; set; }
    }
}