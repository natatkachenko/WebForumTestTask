using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebForumTestTask.Models;

namespace WebForumTestTask.Models
{
    public class ThemeDbInitializer : CreateDatabaseIfNotExists<ForumContext>
    {
        protected override void Seed(ForumContext db)
        {
            db.Themes.Add(new Theme { Id = 1, Title = "Test", Text="Some Text" });

            base.Seed(db);
        }
    }
}