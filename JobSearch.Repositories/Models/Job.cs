using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        public string JobName { get; set; }

        public Skill MainSkill { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public Company Company { get; set; }
    }
}
