using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class National_EduController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: National_Edu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _NationalEdud()
        {
            int AppId = (Convert.ToInt32(Session["Applicant Id"]));
            var obj = (from n1 in db.REG_Number where n1.Applicant_Id == AppId select n1.MAT_SAT_Rollno ).SingleOrDefault();
            int? Mat = obj;
            var obj1= (from n in db.NationalEdu_Details
                      where n.MAT_SAT_Rollno == Mat
                      select n).SingleOrDefault();
            if(obj1!=null)
            {
                return PartialView(obj1);
                
            }
            else
            {
                return RedirectToAction("_NationalEdu");
            }
                
        }
       [HttpGet]
        public ActionResult _NationalEdu()
        {
            int AppId = Convert.ToInt32(Session["Applicant Id"]);
            var obj = (from n1 in db.REG_Number where n1.Applicant_Id == AppId select n1.MAT_SAT_Rollno).SingleOrDefault();
            int? roll = obj;
            var obj1 = (from n in db.NationalEdu_Details
                       where n.MAT_SAT_Rollno == roll
                       select n).SingleOrDefault();
            ViewBag.scheme = obj1;
            var obj2 = (from n in db.REG_Number where n.Applicant_Id == AppId select n.Ssc_Rollno ).SingleOrDefault();
            if (obj1 == null)
            {
                return PartialView();
            }
            else if (obj1 != null && obj1.Nineth_class_per == null)
            {
                return PartialView();
            }
            else if (obj1.Nineth_class_per != null && obj2 == null)
            {
                return PartialView("_Academic", "Academic");
            }
            else
                if ((obj1.Nineth_class_per != null )&& (obj2!=null) && (obj1.Eleventh_class_per==null))
            {
                return PartialView();
            }
            else
            {
                return PartialView("_NationalEdud") ;
            }
        }
        [HttpPost]
        public ActionResult _NationalEdu(NationalEdu_Details nat)
        {
            int AppId = Convert.ToInt32(Session["Applicant Id"]);
            var obj = (from n in db.REG_Number where n.Applicant_Id == AppId select n.MAT_SAT_Rollno ).SingleOrDefault();
            if (nat.MAT_SAT_Score != null && nat.Nineth_class_per == null)
            {
                db.Nat(nat.MAT_SAT_Rollno, nat.MAT_SAT_Score, nat.Eighth_class_per);
                db.SaveChanges();
                db.RegNat(AppId, nat.MAT_SAT_Rollno);
                db.SaveChanges();
                return RedirectToAction("_NationalEdud");
            }
            else
               
                if(nat.Eleventh_class_per==null)
            {
                db.Nat99(obj, nat.Nineth_class_per);
                db.SaveChanges();
                return RedirectToAction("_NationalEdud");

            }
            else
            {
                db.Nat111(obj, nat.Eleventh_class_per, nat.Eleventh_specialization);
                db.SaveChanges();
                return RedirectToAction("_NationalEdud");
            }


            }
        
        }
}