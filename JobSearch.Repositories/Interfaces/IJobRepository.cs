using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Interfaces
{
    public interface IJobRepository
    {
        void AddJob(Job job);

        void RemoveJob(int id);

        List<Job> GetJobs();

        List<Job> GetCompanyJobs(string email);

        Job GetJob(int id);
    }
}
