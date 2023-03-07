using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class Admin : User
    {
        public Admin()
        {
            Role = "Admin";
        }
    }
}
