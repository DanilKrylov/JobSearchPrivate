using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Logic.Interfaces
{
    internal interface IJwtService
    {
        string CreateToken(User user);
    }
}
