using JobSearch.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.API.ViewModels
{
    public class CompanyGoogleRegisterViewModel
    {
        [Required(ErrorMessage = "Should be not required")]
        [EmailAddress(ErrorMessage = "It doesn't look like an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Should be not required")]

        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Should be not required")]

        public string Address { get; set; }

        [Required(ErrorMessage = "Should be not required")]

        public string Description { get; set; }

        public Company ToModel()
        {
            return new Company()
            {
                Email = Email,
                CompanyName = CompanyName,
                Address = Address,
                Description = Description
            };
        }
    }
}
