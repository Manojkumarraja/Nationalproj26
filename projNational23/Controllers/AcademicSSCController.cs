using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class AcademicSSCController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: AcademicSSC
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _AcademicSSCd()
        {
            int AppId = (Convert.ToInt32(Session["Applicant Id"]));
            var obj1 = (from n1 in db.REG_Number where n1.Applicant_Id == AppId select n1.Ssc_Rollno ).SingleOrDefault();
            int? Rollno = obj1;
            var obj = (from n in db.AcademicSSC_Details
                       where n.sscRoll_No == Rollno
                       select n).SingleOrDefault();
            if (obj != null)
            {
                return PartialView(obj);
            }
            else
            {
                return RedirectToAction("_AcademicSSC");
            }
        }
        [HttpGet]
        public ActionResult _AcademicSSC()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult _AcademicSSC(AcademicSSC_Details academicSSC)
        {
            if (ModelState.IsValid)
            {
                int AppId = Convert.ToInt32(Session["Applicant Id"]);
                try{
                    db.AcademicSSC_Details.Add(academicSSC);
                    db.SaveChanges();
                    db.Regssc(AppId, academicSSC.sscRoll_No);
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", "Something went wrong Check the credentials you entered or try again later......");
                    return View(academicSSC);
                }
                
                return RedirectToAction("_AcademicSSCd", "AcademicSSC");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Enter the details in the correct format");
                return View(academicSSC);
            }
        }
        public ActionResult _DetailacademicSSC()
        {
            var obj = (from n in db.AcademicSSC_Details
                       where n.sscRoll_No == ((from n1 in db.REG_Number where n1.Applicant_Id == Convert.ToInt32(Session["Applicant Id"]) select n1.Ssc_Rollno).Single())
                       select n).SingleOrDefault();
            return PartialView(obj);

        }
    }
}