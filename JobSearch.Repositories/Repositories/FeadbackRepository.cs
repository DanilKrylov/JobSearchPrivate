using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JobSearch.Repositories.Repositories
{
    internal class FeadbackRepository : IFeadbackRepository
    {
        private readonly AppContext _context;
        public FeadbackRepository(AppContext context)
        {
            _context = context;
        }

        public void AddFeadback(JobFeadback feadback)
        {
            _context.JobFeadbacks.Add(feadback);
            _context.SaveChanges();
        }

        public JobFeadback GetFeadback(int id)
        {
            return _context.JobFeadbacks.FirstOrDefault(c => c.JobFeadbackId == id);
        }

        public List<JobFeadback> GetUserFeadbacks(string email)
        {
            return _context.Workers
                .Include(c => c.Feadbacks)
                    .ThenInclude(c => c.Job)
                .FirstOrDefault(c => c.Email == email)
                .Feadbacks;
        }

        public void RemoveFeadback(int feadbackId)
        {
            _context.JobFeadbacks.Remove(GetFeadback(feadbackId));
            _context.SaveChanges();
        }

        public void UpdateFeadback(JobFeadback feadback)
        {
            _context.JobFeadbacks.Update(feadback);
            _context.SaveChanges();
        }
    }
}
