using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud__.Models.Entities
{
    public class File
    {
        public int id { get; set; }
        public int folderID { get; set; }
        public string fileName { get; set; }
        public string content { get; set; }
        public string extension { get; set; }
    }
}