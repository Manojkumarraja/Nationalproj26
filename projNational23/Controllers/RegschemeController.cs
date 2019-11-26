using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class RegschemeController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: Regscheme
        public ActionResult Index()
        {
            return View();
        }
            public ActionResult _Regschemed()
            {
            int AppId = (Convert.ToInt32(Session["Applicant Id"]));
                var obj = (from n in db.RegScheme_details
                           where n.Applicant_ID ==AppId
                           select n).SingleOrDefault();
                if (obj != null)
                {
                    return PartialView(obj);
                }
                else
                {
                    return RedirectToAction("_Regscheme");
                }
            }
        public ActionResult _Regscheme()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult _Regscheme(RegScheme_details regScheme)
        {
            if(ModelState.IsValid)
            { int AppId = Convert.ToInt32(Session["Applicant Id"]);
                regScheme.Date_of_apply = DateTime.Now;
                try
                {
                    db.Regscheme(AppId, regScheme.Date_of_apply, regScheme.Smart_Card_Id, regScheme.Acc_No, regScheme.Bank_name, regScheme.IFSC_CODE);
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("","Something Went Wrong Please check the credentials you entered or try again later...");
                    return View(regScheme);
                }
                return RedirectToAction("_Regschemed", "Regscheme");
                
            }
            else
            {
                return PartialView(regScheme);
            }
        }
        public ActionResult _DetailsRegscheme()
        {
            var obj = (from n in db.RegScheme_details
                       where n.Applicant_ID == Convert.ToInt32(Session["Applicant Id"])
                       select n).SingleOrDefault();
            return PartialView(obj);
        }

    }
}