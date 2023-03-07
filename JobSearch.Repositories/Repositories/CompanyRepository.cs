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
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly AppContext _context;
        public CompanyRepository(AppContext context)
        {
            _context = context;
        }

        public Company Get(int id)
        {
            return _context.Companies
                .Include(c => c.Jobs)
                .ThenInclude(c => c.Feadbacks)
                .FirstOrDefault(c => c.UserId == id);
        }

        public List<Company> GetAll()
        {
            return _context.Companies.ToList();
        }
    }
}
