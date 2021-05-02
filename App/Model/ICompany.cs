using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaDesignTask.Models
{
    public class ICompany
    {   
        public string name { get; set; }
        public string address { get; set; }
        public string business { get; set; }
        
        public virtual ICollection<Physicalusers> Users { get; set; }

        public ICompany()
        {
            Users = new List<Physicalusers>();
        }

    }
}
