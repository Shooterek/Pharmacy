﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Exceptions;
using Pharmacy.Infrastructure.Services.Interfaces;
using ErrorCodes = Pharmacy.Infrastructure.Exceptions.ErrorCodes;

namespace Pharmacy.Infrastructure.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var drivers = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(drivers);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user == null)
            {
                throw new ServiceException(ErrorCodes.UserNotFound,
                    "User not found");
            }

            if (!user.IsActive)
            {
                throw new ServiceException(ErrorCodes.InactiveUserLoginAttempt,
                    "Inactive user login attempt");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new ServiceException(ErrorCodes.InvalidCredentials,
                "Invalid credentials");
        }

        public async Task UpdateAsync(UserDto user)
        {
            await _userRepository.UpdateAsync(_mapper.Map<UserDto, User>(user));
        }

        public async Task RegisterAsync(RegisterUserDto registerUserDto)
        {
            var user = await _userRepository.GetAsync(registerUserDto.Email);
            if (user != null)
            {
                throw new ServiceException(ErrorCodes.EmailInUse,
                    $"User with email: '{registerUserDto.Email}' already exists.");
            }

            var salt = _encrypter.GetSalt(registerUserDto.Password);
            var hash = _encrypter.GetHash(registerUserDto.Password, salt);
            user = new User(Guid.NewGuid(), registerUserDto.Email, registerUserDto.Username, registerUserDto.Fullname,
                registerUserDto.Role, registerUserDto.Education, hash, salt);
            await _userRepository.AddAsync(user);
        }
    }
}