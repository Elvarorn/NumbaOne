using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud__.Models.Entities
{
    public class Project
    {
        public Project()
        {
            Users = new List<ApplicationUser>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }


    }
}