using JobSearch.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.API.ViewModels
{
    public class WorkerRegisterViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ResumeInfo { get; set; }

        public int MainSkillId { get; set; }

        public Worker ToModel()
        {
            return new Worker()
            {
                Name = Name,
                Email = Email,
                Password = Password,
                Surname = Surname,
                ResumeInfo = ResumeInfo,
                MainSkillSkillId = MainSkillId
            };
        }
    }
}
