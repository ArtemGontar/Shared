using Microsoft.AspNetCore.Identity;
using Shared.Common;
using System;

namespace Shared.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public EnglishLevel EnglishLevel { get; set; }

        public DateTime BirthDate { get; set; }

        public string Departament { get; set; }

        public string JobTitle { get; set; }
    }
}
