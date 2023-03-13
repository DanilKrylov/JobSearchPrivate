using JobSearch.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.API.ViewModels
{
    public class CompanyRegisterViewModel
    {
        [Required(ErrorMessage = "Should be not required")]
        [EmailAddress(ErrorMessage = "It doesn't look like an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Should be not required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Should be not required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Field should contains from 5 to 30 symbols")]

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
                Password = Password,
                CompanyName = CompanyName,
                Address = Address,
                Description = Description
            };
        }
    }
}
