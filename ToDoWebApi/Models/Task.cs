using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoWebApi.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Priority { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public string TaskDescription { get; set; }
        public string TaskStatus { get; set; }

        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }

        public int CollaboratorID { get; set; }
        public virtual Collaborator Collaborator { get; set; }
    }
}