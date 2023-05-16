using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<Admin> GetAdmins();

        List<Company> GetCompanies();

        List<Worker> GetWorkers();
        Worker GetWorker(string email);

        User GetUser(string login);

        void AddUser(User user);

        void EditUser(User user);

        void BanCompanyOrWorker(string email);

        void UnbanCompanyOrWorker(string email);

        bool EmailIsUnique(string email);

        bool CanLogin(string email, string password);

        bool CanGoogleLogin(string email);
    }
}
