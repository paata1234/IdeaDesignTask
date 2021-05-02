using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaDesignTask.Models
{
    public class Users
    {     
        public string name { get; set; }
        public string surname { get; set; }
        public string sex { get; set; }
        public string personalid { get; set; }
        public DateTime date { get; set; }
        public string city { get; set; }
        public string phonenumber { get; set; }
        public virtual ICollection<ICompany> Company { get; set; }
        public Users()
        {
            Company = new List<ICompany>();
        }
        }
}
