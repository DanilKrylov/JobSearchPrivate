using JobSearch.Logic.Interfaces;
using JobSearch.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Logic
{
    public static class LogicServiceRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
