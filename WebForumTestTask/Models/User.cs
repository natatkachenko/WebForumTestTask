using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Task.Models
{
    public class User
    {
        // UserId
        public int Id { get; set; }

        // LoginName
        public string Login { get; set; }

        // Email
        public string Email { get; set; }

        // Password
        public string Password { get; set; }
    }
}