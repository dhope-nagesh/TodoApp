using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoWebApi.Models
{
    public class Collaborator
    {
        public int CollaboratorID { get; set; }
        public string CollaboratorName { get; set; }

        public virtual List<Project> Projects { get; set; }
    }
}