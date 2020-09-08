using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebForumTestTask.Models
{
    public class ForumContext : IdentityDbContext<User>
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ForumContext() : base("DefaultConnection") { }
        public static ForumContext Create()
        {
            return new ForumContext();
        }
    }
}