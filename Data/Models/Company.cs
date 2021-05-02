using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaDesignTask.Models
{
    public class Company
    {   
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "სახელის ველი აუცილებლად შესავსებია !")]
        public string name { get; set; }
        [Required(ErrorMessage = "მისამართის ველი აუცილებლად შესავსებია !")]
        public string address { get; set; }
        [Required(ErrorMessage = "საქმიანობის ველი აუცილებლად შესავსებია !")]
        public string business { get; set; }
        
        public virtual ICollection<Physicalusers> Users { get; set; }

        public Company()
        {
            Users = new List<Physicalusers>();
        }

    }
}
