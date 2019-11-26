using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class AdminprofController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: Adminprof
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _EdProfile()
        {
            string LoginId = Session["Login Id"].ToString();
            var obj = (from n in db.Admin_Details
                       where n.Login_Id == LoginId
                       select n).SingleOrDefault();
            Session["Admin Id"] = obj.Admin_Id;
            if(obj==null)
            {
                return RedirectToAction("_AdProfile");
            }
            else
            {
                return RedirectToAction("_Updateprofile");
            }
        }
        public ActionResult _AdProfile()
        {

            return PartialView();
        }
        [HttpPost]
        public ActionResult _AdProfile(Admin_Details admin_Details)
        {
            admin_Details.Login_Id = Session["Login Id"].ToString();
            db.Admin_Details.Add(admin_Details);
            try
            {
                db.SaveChanges();
                return PartialView("_AdProfiledet");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Something Went Wrong Please Try Again Later!!!");
                return PartialView(admin_Details);
            }

        }
        public ActionResult _Updateprofile()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult _Updateprofile(Admin_Details admin_Details)
        {
            admin_Details.Admin_Id = Convert.ToInt32(Session["Admin Id"]);
            db.Admin_Details.Add(admin_Details);
            db.SaveChanges();
            return PartialView("_AdProfiledet");
        }
    }
}