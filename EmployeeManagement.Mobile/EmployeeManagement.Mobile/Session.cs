﻿using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Core.Models;

namespace EmployeeManagement.Mobile
{
    public static class Session
    {
        public static UserDto User { get; set; }
        // TESTOWO!!!
        = new UserDto
        {
            Employee = new Employee { Id = 1 }
        };
    }
}