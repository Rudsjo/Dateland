using Dateland.Test2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateland.Test2
{
    public class UserViewModel : IUser
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAdress { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string ConfirmEmail { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
