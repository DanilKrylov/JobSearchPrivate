using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Repositories
{
    internal class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppContext _context;
        private readonly UserRepository _userRepository;

        public void Add(string email, int jobId)
        {
            var user = _userRepository.GetUser(email);
            _context.FavoriteJobs.Add(new FavoriteJob()
            {
                JobId = jobId,
                WorkerUserId = user.UserId
            });

            _context.SaveChanges();
        }

        public List<Job> GetFavorites(string email)
        {
            throw new NotImplementedException();
        }

        public void Remove(string email, int jobId)
        {
            var user = _userRepository.GetUser(email);
            _context.FavoriteJobs.Remove(_context.FavoriteJobs.First(c => c.WorkerUserId == user.UserId && c.JobId == jobId));

            _context.SaveChanges();
        }
    }
}
