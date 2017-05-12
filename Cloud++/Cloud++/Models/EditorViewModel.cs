using Cloud__.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud__.Models
{
    public class EditorViewModel
    {
        public string Content { get; set; }
        public int FileID { get;  set; }
        public string userID { get; set; }
        public List<File> Files { get; set; }

    }
}