using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud__.Models.Entities
{
    public class Folder
    {
        public int id { get; set; }
        public string folderName { get; set; }
        public int projectID { get; set; }
        public int parentFolderID { get; set; }
    }
}