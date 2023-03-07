using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context)
        {
            _context = context;
        }

        public List<Admin> GetAdmins()
        {
            var admin = new Admin()
            {
                Email = "test"
            };


            _context.Admins.Add(admin);
            _context.SaveChanges();


            return _context.Admins.ToList();
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
