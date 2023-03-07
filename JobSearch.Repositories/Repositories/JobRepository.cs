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
    internal class JobRepository : IJobRepository
    {
        private readonly AppContext _context;
        public JobRepository(AppContext context)
        {
            _context = context;
        }


        public void AddJob(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public List<Job> GetCompanyJobs(string email)
        {
            var result = _context.Companies
               .Include(c => c.Jobs)
               .FirstOrDefault(c => c.Email == email)
               .Jobs;

            return result;
        }

        public Job GetJob(int id)
        {
            return _context.Jobs
                .Include(c => c.MainSkill)
                .Include(c => c.Company)
                .Include(c => c.Feadbacks)
                    .ThenInclude(c => c.Worker)
                .FirstOrDefault(c => c.JobId == id);
        }

        public List<Job> GetJobs()
        {
            return _context.Jobs
                .Include(c => c.MainSkill)
                .Include(c => c.Company)
                .ToList();
        }

        public void RemoveJob(int id)
        {
            _context.Jobs.Remove(GetJob(id));
            _context.SaveChanges();
        }
    }
}
