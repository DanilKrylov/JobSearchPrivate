﻿using JobSearch.Logic.Interfaces;
using JobSearch.Logic.Models;
using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobSearch.Logic.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        
        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }


        public AuthorizeOperationResult CompanyRegister(Company company)
        {
            if (!_userRepository.EmailIsUnique(company.Email))
            {
                var res = new AuthorizeOperationResult(false);
                res.AddError("email", "this email is already taken");
                return res;
            }

            _userRepository.AddUser(company);

            var token = _jwtService.CreateToken(_userRepository.GetUser(company.Email));
            return new AuthorizeOperationResult(true, token);
        }

        public AuthorizeOperationResult Login(string login, string password)
        {
            if (!_userRepository.CanLogin(login, password))
            {
                var res = new AuthorizeOperationResult(false);
                res.AddError("password", "password or email enterd incorectly");
                return res;
            }


            var token = _jwtService.CreateToken(_userRepository.GetUser(login));
            return new AuthorizeOperationResult(true, token);
        }

        public AuthorizeOperationResult WorkerRegister(Worker worker)
        {
            if (!_userRepository.EmailIsUnique(worker.Email))
            {
                var res = new AuthorizeOperationResult(false);
                res.AddError("email", "this email is already taken");
                return res;
            }
            _userRepository.AddUser(worker);

            var token = _jwtService.CreateToken(_userRepository.GetUser(worker.Email));
            return new AuthorizeOperationResult(true, token);
        }
    }
}
