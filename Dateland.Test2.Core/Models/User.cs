using System;
using System.Collections.Generic;
using System.Text;

namespace Dateland.Test2.Core
{
    public class User : IUser
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAdress { get; set; }

        public string ProfilePictureUrl { get; set; }

    }
}
