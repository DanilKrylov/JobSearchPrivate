using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class Company : User
    {
        public Company()
        {
            Role = "Company";
        }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public List<Job> Jobs { get; set; } = new();
    }
}
