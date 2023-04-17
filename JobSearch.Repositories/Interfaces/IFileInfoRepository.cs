using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Interfaces
{
    public interface IFileInfoRepository
    {
        void SetCV(IFormFile formFile, string email);

        void SetAvatar(IFormFile formFile, string email);

        byte[] GetCV(string email);
    }
}
