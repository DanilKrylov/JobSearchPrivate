using JobSearch.Repositories;
using JobSearch.Repositories.Models;
using System.Linq;

namespace JobSearch.API
{
    public static class AdminInitializer
    {
        public static void InitAdmins(AppContext appContext)
        {
            var admin = new Admin()
            {
                Email = "admin@gmail.com",
                Password = "123456aA_",
            };

            if (appContext.Admins.Any(c => c.Email == admin.Email))
                return;

            appContext.Admins.Add(admin);
            appContext.SaveChanges();
        }
    }
}
