using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        public string TagName { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
