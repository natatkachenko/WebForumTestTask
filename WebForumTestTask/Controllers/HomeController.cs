using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Task.Models;

namespace Test_Task.Controllers
{
    public class HomeController : Controller
    {
        // create data context
        ForumContext db = new ForumContext();

        public ActionResult Index()
        {
            // get all Theme objects
            IEnumerable<Theme> themes = db.Themes;
            // transfer Theme objects to Themes property in ViewBag
            ViewBag.Themes = themes;

            return View();
        }
    }
}