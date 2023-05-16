using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Repositories
{
    internal class FileInfoRepository : IFileInfoRepository
    {
        private readonly IUserRepository _userRepository;

        public FileInfoRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public byte[] GetCV(string email)
        {
            var user = (Worker)_userRepository.GetWorker(email);
            return user.CV?.Content;
        }

        public void SetAvatar(IFormFile formFile, string email)
        {
            var user = (Worker)_userRepository.GetUser(email);
            user.Avatar = new Models.FileInfo
            {
                Content = FileToBytes(formFile),
            };

            _userRepository.EditUser(user);
        }

        public void SetCV(IFormFile formFile, string email)
        {
            var user = (Worker)_userRepository.GetUser(email);
            user.CV = new Models.FileInfo
            {
                Content = FileToBytes(formFile),
            };

            _userRepository.EditUser(user);
        }

        private byte[] FileToBytes(IFormFile formFile)
        {
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(formFile.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)formFile.Length);
            }

            return imageData;
        }
    }
}
