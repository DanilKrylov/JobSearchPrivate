using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class FavoriteJob
    {
        public int FavoriteJobId { get; set; }

        public int WorkerUserId { get; set; }
        public Worker Worker { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
