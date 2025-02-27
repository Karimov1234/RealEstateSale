﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identities
{
    public class AppUser : IdentityUser<string>
    {
        public DateTime BirthDay { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndTime { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
