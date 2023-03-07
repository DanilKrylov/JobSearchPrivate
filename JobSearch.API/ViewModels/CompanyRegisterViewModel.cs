using JobSearch.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.API.ViewModels
{
    public class CompanyRegisterViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public Company ToModel()
        {
            return new Company()
            {
                Email = Email,
                Password = Password,
                CompanyName = CompanyName,
                Address = Address,
                Description = Description
            };
        }
    }
}
