﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.IdentityDtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}