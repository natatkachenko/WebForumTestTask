using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebForumTestTask.Models;
using WebForumTestTask.ViewModels;

namespace WebForumTestTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // create data context
        ForumContext db = new ForumContext();

        // start page with list of themes
        public ActionResult Index()
        {
            // get all Theme objects
            IEnumerable<Theme> themes = db.Themes;
            // transfer Theme objects to Themes property in ViewBag
            ViewBag.Themes = themes;

            return View();
        }

        // text of certain theme
        [HttpGet]
        public ActionResult Posts(int? id)
        {
            if (id != null)
            {
                Theme theme = db.Themes.FirstOrDefault(t => t.Id == id);
                if (theme != null)
                {
                    var model = new ThemeViewModel();
                    model.Theme = theme;
                    model.Posts = db.Posts
                        .Where(p => p.ThemeId == id)
                        .Join(db.Users,
                        p => p.UserId,
                        u => u.Id,
                        (p, u) => new PostUser
                        {
                            Post = p,
                            User = u
                        }).ToList();
                    return View(model);
                }
            }
            return HttpNotFound();
        }

        // Add new topic
        public ActionResult Add()
        {
            return View();
        }

        // Save new topic in DB
        [HttpPost]
        public async Task<ActionResult> Add(Theme theme)
        {
            db.Themes.Add(theme);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}