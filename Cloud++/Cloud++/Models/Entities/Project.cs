using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud__.Models.Entities
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}