using System.Collections.Generic;

namespace JobSearch.API.ViewModels
{
    public class JobAddViewModel
    {
        public string JobName { get; set; }
        public string Description { get; set; }

        public List<int> TagIdes { get; set; }
    }
}
