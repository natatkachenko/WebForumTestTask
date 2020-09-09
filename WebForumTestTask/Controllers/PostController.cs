using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForumTestTask.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace WebForumTestTask.Controllers
{
    public class PostController : Controller
    {
        // create data context
        ForumContext db = new ForumContext();

        // Add new post
        public ActionResult Add()
        {
            return View();
        }

        // Save new post in DB
        [HttpPost]
        public async Task<ActionResult> Add(Post post)
        {
            post.UserId = User.Identity.GetUserId<string>();
            post.PostDate = DateTime.Now;
            post.UpdateDate = DateTime.Now;
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return RedirectToAction($"Details/{post.ThemeId}", "Home");
        }

        // Edit post
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Post post = db.Posts.FirstOrDefault(p => p.Id == id);
                return View(post);
            }
            return HttpNotFound();
        }

        // Save post changes in DB
        [HttpPost]
        public async Task<ActionResult> Edit(Post post)
        {
            post.UpdateDate = DateTime.Now;
            db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction($"Details/{post.ThemeId}", "Home");
        }
    }
}