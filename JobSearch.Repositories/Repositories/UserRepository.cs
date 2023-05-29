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

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void BanCompanyOrWorker(string email)
        {
            var worker = _context.Workers.FirstOrDefault(c => c.Email == email);
            var company = _context.Companies.FirstOrDefault(c => c.Email == email);

            if (worker is not null)
                worker.IsBanned = true;

            if (company is not null)
                company.IsBanned = true;

            _context.SaveChanges();
        }

        public bool CanLogin(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(c => c.Email == email);

            return user is not null && user.Password == password;
        }

        public bool CanGoogleLogin(string email)
        {
            var user = _context.Users.FirstOrDefault(c => c.Email == email);

            return user is not null;
        }

        public void EditUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges(true);
        }

        public bool EmailIsUnique(string email)
        {
            return !_context.Users.Any(c => c.Email == email);
        }

        public List<Admin> GetAdmins()
        {
            return _context.Admins.ToList();
        }

        public List<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public User GetUser(string login)
        {
            return _context.Users.FirstOrDefault(c => c.Email == login);
        }

        public List<Worker> GetWorkers()
        {
            return _context.Workers.Include(c => c.Avatar)
                .Include(c => c.Tag).ToList();
        }

        public void UnbanCompanyOrWorker(string email)
        {
            var worker = _context.Workers.FirstOrDefault(c => c.Email == email);
            var company = _context.Companies.FirstOrDefault(c => c.Email == email);

            if (worker is not null)
                worker.IsBanned = false;

            if (company is not null)
                company.IsBanned = false;

            _context.SaveChanges();
        }

        public Worker GetWorker(string email)
        {
            return _context.Workers.Include(c => c.CV).FirstOrDefault(c => c.Email == email);
        }
    }
}
