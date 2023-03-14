using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class JobFeadback
    {
        [Key]
        public int JobFeadbackId { get; set; }

        public Worker Worker { get; set; }

        public Job Job { get; set; }

        public string WorkerComment { get; set; }

        public bool? Accepted { get; set; }
    }
}
