using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();

        Company Get(int id);
    }
}
