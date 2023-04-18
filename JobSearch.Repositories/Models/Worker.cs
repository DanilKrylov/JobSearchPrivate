using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class Worker : User
    {
        public Worker()
        {
            Role = "Worker";
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        [StringLength(1000)]
        public string ResumeInfo { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public FileInfo Avatar { get; set; }

        public FileInfo CV { get; set; }

        public List<JobFeadback> Feadbacks { get; set;} = new List<JobFeadback>();
    }
}
