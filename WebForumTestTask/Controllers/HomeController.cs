using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForumTestTask.Models;

namespace WebForumTestTask.Controllers
{
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
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Theme theme = db.Themes.FirstOrDefault(t => t.Id == id);
                if (theme != null)
                    return View(theme);
            }
            return HttpNotFound();
        }
    }
}