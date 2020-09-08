using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace WebForumTestTask.Models
{
    public class UserManager:UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {

        }
        public static UserManager Create(IdentityFactoryOptions<UserManager> options,
            IOwinContext context)
        {
            ForumContext db = context.Get<ForumContext>();
            UserManager manager = new UserManager(new UserStore<User>(db));
            return manager;
        }
    }
}