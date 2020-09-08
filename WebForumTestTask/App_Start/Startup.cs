using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using WebForumTestTask.Models;

[assembly: OwinStartup(typeof(WebForumTestTask.App_Start.Startup))]

namespace WebForumTestTask.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //setting context and manager
            app.CreatePerOwinContext<ForumContext>(ForumContext.Create);
            app.CreatePerOwinContext<UserManager>(UserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}