using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.EntityFrameworkCore;
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
            return _context.Admins.ToList();
        }

        public List<Company> GetCompanies(int jobId)
        {
            var job = _context.Jobs.Include(job => job.Company)
                .FirstOrDefault(job => job.JobId == jobId);
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
