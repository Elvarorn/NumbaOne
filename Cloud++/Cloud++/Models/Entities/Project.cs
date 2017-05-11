using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cloud__.Models.Entities
{
    [Table("Projects")]

    public class Project
    {
        public Project()
        {
            Users = new List<ApplicationUser>();
        }

        
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }


    }
}