using System.ComponentModel.DataAnnotations;

namespace JobSearch.API.ViewModels
{
    public class UpdateCompanyViewModel
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}
