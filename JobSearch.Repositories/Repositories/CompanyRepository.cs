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

        public Company Get(string email)
        {
            return _context.Companies
                .Include(c => c.Jobs)
                .ThenInclude(c => c.Feadbacks)
                .Include(c => c.Jobs)
                .ThenInclude(c => c.Tags)
                .FirstOrDefault(c => c.Email == email);
        }

        public List<Company> GetAll()
        {
            return _context.Companies.Include(x => x.Jobs).ToList();
        }

        public void Update(string email, string name, string description, string address)
        {
            var company = Get(email);
            company.Address = address;
            company.Description = description;
            company.CompanyName = name;
            _context.Companies.Update(company);
            _context.SaveChanges();
        }
    }
}
