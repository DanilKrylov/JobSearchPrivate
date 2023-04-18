using JobSearch.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.API.ViewModels
{
    public class WorkerRegisterViewModel
    {
        [Required(ErrorMessage = "Should be not required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Should be not required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Should be not required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Should be not required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Should be not required")]
        public string ResumeInfo { get; set; }

        [Required(ErrorMessage = "Should be not required")]
        public int TagId { get; set; }

        public Worker ToModel()
        {
            return new Worker()
            {
                Name = Name,
                Email = Email,
                Password = Password,
                Surname = Surname,
                ResumeInfo = ResumeInfo,
                TagId = TagId
            };
        }
    }
}
