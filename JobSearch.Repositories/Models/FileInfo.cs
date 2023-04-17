using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class FileInfo
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }
    }
}
