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

        User GetUser(string login);

        void AddUser(User user);

        void EditUser(User user);

        void BanCompanyOrWorker(int userId);

        void UnbanCompanyOrWorker(int userId);

        bool EmailIsUnique(string email);

        bool CanLogin(string email, string password);
    }
}
