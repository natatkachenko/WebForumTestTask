using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForumTestTask.Models;
using System.Threading.Tasks;

namespace WebForumTestTask.Controllers
{
    public class PostController : Controller
    {
        // create data context
        ForumContext db = new ForumContext();

        // start page with comments of certain theme
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                Post post = db.Posts.FirstOrDefault(p => p.ThemeId == id);
                if (post != null)
                    return View(post);
                else
                    return RedirectToAction("NoMessage");
            }
            return HttpNotFound();
        }
        // if there are no messages for certain topic
        public ActionResult NoMessage()
        {
            return View();
        }

        // Add new post
        public ActionResult Add()
        {
            SelectList themes = new SelectList(db.Themes, "Id", "Title");
            SelectList users = new SelectList(db.Users, "Id", "Login");
            ViewBag.Themes = themes;
            ViewBag.Users = users;
            return View();
        }

        // Save new post in DB
        [HttpPost]
        public async Task<ActionResult> Add(Post post)
        {
            //post.UserId = User.Identity.GetUserId();
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}