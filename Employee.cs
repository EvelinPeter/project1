using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormProject
{
   public class Employee
    {
            public string ID { get; set; }
            public string Name { get; set; }
           public DateTime Date { get; set; }
           public string Role { get; set; }
           public string Password { get; set; }

    }


    public class Notice { 
    
            public string ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public string Post { get; set; }
    }

    public class Issue
    {

        public int IssueID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

       public DateTime PostOn { get; set; }

        public string PostBy { get; set; } = "";

       public Status Status { get; set; }
    }
}
