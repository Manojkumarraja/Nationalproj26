using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class ViewstatController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: Viewstat
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _ViewStatus()
        {
            int AppId = Convert.ToInt32(Session["Applicant Id"]);
            var obj = (from n in db.RegScheme_details
                       where n.Applicant_ID == AppId
                       select n).SingleOrDefault();
            return PartialView(obj);
        }
    }
}