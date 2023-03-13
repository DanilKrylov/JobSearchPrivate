using JobSearch.Logic.Models;
using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Logic.Interfaces
{
    public interface IAuthService
    {
        public AuthorizeOperationResult Login(string username, string password);

        public AuthorizeOperationResult Login(string username);

        public AuthorizeOperationResult CompanyRegister(Company company);

        public AuthorizeOperationResult WorkerRegister(Worker company);

        public bool IsBanned(string email);
    }
}
