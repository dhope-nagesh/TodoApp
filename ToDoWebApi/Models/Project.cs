using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoWebApi.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }


        public virtual List<Collaborator> Collaborators { get; set; }
    }
}