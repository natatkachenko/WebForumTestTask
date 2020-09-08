using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebForumTestTask.Models
{
    public class User : IdentityUser
    {
        public User() { }
        // LoginName
        public string Login { get; set; }
    }
}