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
                .Include(c => c.Tags)
                .Include(c => c.Company)
                .Include(c => c.Feadbacks)
                    .ThenInclude(c => c.Worker)
                    .ThenInclude(c => c.Tag)
                .FirstOrDefault(c => c.JobId == id);
        }

        public List<Job> GetJobs()
        {
            var test = _context.Jobs
                .Include(c => c.Tags)
                .Include(c => c.Company)
                .Select(c => new Job()
                {
                    Company = c.Company,
                    JobId = c.JobId,
                    JobName = c.JobName,
                    Description = c.Description,
                    Feadbacks = c.Feadbacks,
                    Tags = c.Tags.Select(t => new Tag()
                    {
                        TagId = t.TagId,
                        TagName = t.TagName,
                    }).ToList(),
                }).ToList();
            return test;
        }


        public List<Job> GetFavoriteJobs(string email)
        {
            var user = _context.Users.First(c => c.Email == email);
            return _context.FavoriteJobs
                .Include(c => c.Job)
                    .ThenInclude(c => c.Tags)
                .Include(c => c.Job)
                    .ThenInclude(c => c.Company)
                .Where(c => c.WorkerUserId == user.UserId)
                .Select(c => c.Job).ToList();
        }

        public void RemoveJob(int id)
        {
            _context.Jobs.Remove(GetJob(id));
            _context.SaveChanges();
        }
    }
}
