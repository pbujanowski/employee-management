using AutoMapper;
using EmployeeManagement.API.Data;
using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.API.Services
{
    public class AuthenticationService : ServiceBase, IAuthenticationService<UserDto>
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AuthenticationService(ApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration)
            : base(dbContext)
        {
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public UserDto Authenticate(string username, string password)
        {
            var user = dbContext.Users
                .Where(u => u.Username == username && u.Password == password)
                .SingleOrDefault();

            if (user == null)
                return null;

            var employee = dbContext.Employees
                .Where(e => e.Id == user.EmployeeId)
                .SingleOrDefault();

            user.Employee = employee;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userDto = mapper.Map<UserDto>(user);
            userDto.Token = tokenHandler.WriteToken(token);
            return userDto;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = dbContext.Users.ToList();
            var userDtos = new List<UserDto>();

            foreach (var user in users)
                userDtos.Add(mapper.Map<UserDto>(user));

            return userDtos;
        }

        public UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}