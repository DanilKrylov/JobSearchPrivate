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

        public Skill MainSkill { get; set; }

        public bool IsBanned { get; set; } = false;
    }
}
