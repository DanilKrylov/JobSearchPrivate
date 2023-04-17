using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories
{
    public static class StoreServiceRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<AppContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IFeadbackRepository, FeadbackRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IFileInfoRepository, FileInfoRepository>();
        }
    }
}
