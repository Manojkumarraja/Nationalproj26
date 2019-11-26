using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class AcademicHSCController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: AcademicHSC
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _AcademicHSCd()
        {
            int Appid = (Convert.ToInt32(Session["Applicant Id"]));
            var res = (from n1 in db.REG_Number where n1.Applicant_Id == Appid select n1.Hsc_Rollno ).SingleOrDefault();
            int? Rollnum = res;
            var obj = (from n in db.AcademicHSC_Details
                       where n.Roll_No == Rollnum
                       select n).SingleOrDefault();
            if (obj != null)
            {
                return PartialView(obj);
            }
            else
            {
                return RedirectToAction("_AcademicHSC");
            }
        }
        public ActionResult _AcademicHSC()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult _AcademicHSC(AcademicHSC_Details academicHSC)
        {
            if (ModelState.IsValid)
            {
                int AppId = Convert.ToInt32(Session["Applicant Id"]);
                try
                {
                    db.AcademicHSC_Details.Add(academicHSC);
                    db.SaveChanges();
                    db.Reghsc(AppId, academicHSC.Roll_No);
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    ModelState.AddModelError(String.Empty, "Something went wrong Check the credentials you entered or try again later......");
                }
                return RedirectToAction("_AcademicHSCd", "AcademicHSC");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Enter the Valid credentials");
                return PartialView(academicHSC);
            }
        }
        public ActionResult _DetailacademicHSC()
        {
            var obj = (from n in db.AcademicHSC_Details
                       where n.Roll_No == ((from n1 in db.REG_Number where n1.Applicant_Id == Convert.ToInt32(Session["Applicant Id"]) select n1.Hsc_Rollno).Single())
                       select n).SingleOrDefault();
            return PartialView(obj);
                     
        }

    }
}