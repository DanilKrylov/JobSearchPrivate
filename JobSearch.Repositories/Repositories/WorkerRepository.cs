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
    internal class WorkerRepository : IWorkerRepository
    {
        private readonly AppContext _context;

        public WorkerRepository(AppContext context)
        {
            _context = context;
        }


        public Worker GetWorker(int id)
        {
            return _context.Workers
                .Include(c => c.Feadbacks)
                .Include(c => c.Tag)
                .Include(c => c.Avatar)
                .FirstOrDefault(c => c.UserId == id);
        }

        public List<Worker> GetWorkers()
        {
            return _context.Workers.ToList();
        }
    }
}
