using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Interfaces
{
    public interface IFavoriteRepository
    {
        void Add(string email, int jobId);

        void Remove(string email, int jobId);

        List<Job> GetFavorites(string email);
    }
}
