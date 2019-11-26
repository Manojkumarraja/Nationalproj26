using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class AdminviewController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: Adminview
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Adminview()
        {
            var res = db.viewapp().SingleOrDefault();
            return PartialView(res);
        }
    }
}