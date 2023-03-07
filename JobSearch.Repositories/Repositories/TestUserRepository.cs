using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Repositories
{
    internal class TestUserRepository : IUserRepository
    {
        public List<Admin> GetAdmins()
        {
            return new Admin[] { new Admin() }.ToList();
        }

        public List<Company> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public List<Worker> GetWorkers()
        {
            throw new NotImplementedException();
        }

        public bool LoginIsUnique()
        {
            throw new NotImplementedException();
        }
    }
}
