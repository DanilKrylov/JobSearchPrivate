using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Interfaces
{
    public interface IFeadbackRepository
    {
        void AddFeadback(JobFeadback feadback);

        void UpdateFeadback(JobFeadback feadback);

        void RemoveFeadback(int feadbackId);

        JobFeadback GetFeadback(int id);

        List<JobFeadback> GetUserFeadbacks(string email);
    }
}
