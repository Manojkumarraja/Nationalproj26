using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{

    public class AcademicController : Controller
    {
      
        NationEntities db = new NationEntities();
        // GET: Academic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Academicd()
        {
            int AppId = Convert.ToInt32(Session["Applicant Id"]);
            var res=(from n1 in db.REG_Number where n1.Applicant_Id == AppId select n1.Register_Number).SingleOrDefault();
            string Regnum = res;
            var obj = (from n in db.Academic_Details
                       where n.Register_No == Regnum
                       select n).SingleOrDefault();
            if(obj!=null)
            {
                return PartialView(obj);
            }
            else
            {
                return RedirectToAction("_Academic");
            }
        }
        public ActionResult _Academic()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Academic(Academic_Details academic)
        {
            if (ModelState.IsValid)
            {
                int AppId = Convert.ToInt32(Session["Applicant Id"]);
                int SchemeId = Convert.ToInt32(Session["Scheme ID"]);
                var obj = (from n in db.Scheme_Details
                           where n.Scheme_Id == SchemeId
                           select new { n.Marks_Criteria }).SingleOrDefault();
                if (academic.Degree_Percentage >= Convert.ToInt32(obj) && academic.Mode_Of_Study == "Regular")
                {
                    try
                    {
                        db.Academic_Details.Add(academic);
                        db.SaveChanges();
                        db.Regdeg(AppId, academic.Register_No);
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
                    return PartialView(academic);
                }
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Enter the Valid credentials");
                return PartialView(academic);
            }
        }

        public ActionResult _Detailacademic()
        {

            int AppId = Convert.ToInt32(Session["Applicant Id"]);
            string Regnum = (from n1 in db.REG_Number where n1.Applicant_Id == AppId select n1.Register_Number).ToString();
            var obj = (from n in db.Academic_Details
                       where n.Register_No == Regnum
                       select n).SingleOrDefault();
            return PartialView(obj);
        }
    }

    }
