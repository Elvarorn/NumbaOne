using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cloud__.Models.Entities
{
    public class File
    {
        [Key]
        public int id { get; set; }
        public string fileName { get; set; }
        public string content { get; set; }
        public string extension { get; set; }

        public int projectId { get; set; }

        [ForeignKey("projectId")]
        public virtual Project Project { get; set; }
    }
}