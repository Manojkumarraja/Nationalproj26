using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class ApplicantController : Controller
    {
     
        NationEntities db = new NationEntities();
        // GET: Applicant
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult _Applicantd()

        {
            string LoginId = Convert.ToString(Session["Login Id"]);

           var obj =( from n1 in db.Applicant_Details
                      where n1.Login_Id ==LoginId
                      select n1).SingleOrDefault();
           
            if (obj!=null)
            {
                Session["Applicant Id"] = obj.Applicant_Id;
                return PartialView(obj);
            }
            else
            {
                return RedirectToAction("_Applicant");

            }
        }
        public ActionResult _Applicant()
        {
            ViewBag.Scheme = (from n in db.Scheme_Details
                              select new { n.Scheme_Id, n.Scheme_Name }).ToList();
            return PartialView();
        }
        [HttpPost]
        public ActionResult _Applicant(Applicant_Details applicant)
        {
            if (!ModelState.IsValid)
            {
                string LoginId = Convert.ToString(Session["Login Id"]);
                applicant.Login_Id = LoginId;
                var obj = (from n in db.Scheme_Details
                           where n.Scheme_Id == applicant.Scheme_Id
                           select n).SingleOrDefault();
                var today = DateTime.Today;
                string qual = "8";
                int age = today.Year - applicant.Date_Of_Birth.Year;
                if (((applicant.Qualification == obj.Qualification_Details.Qualification1) || (applicant.Qualification == obj.Qualification_Details.Qualification2)) && (age == obj.Age_Criteria) && ((applicant.Caste == obj.Caste_Details.Caste1) ||
                   (applicant.Caste == obj.Caste_Details.Caste2) || (applicant.Caste == obj.Caste_Details.Caste3)) && (applicant.Annual_Income <= obj.Annual_Income) &&
                   (applicant.Economic_Backward_Class == obj.Economic_Backward_Class_Details.Condition_1) || (applicant.Economic_Backward_Class == obj.Economic_Backward_Class_Details.condition_2) &&
                   ((applicant.Gender == obj.Gender_Details.gender_1) || (applicant.Gender == obj.Gender_Details.gender_2) || (applicant.Gender == obj.Gender_Details.gender_3)))
                {
                    try
                    {
                        db.Applicant_Details.Add(applicant);
                        db.SaveChanges();
                    }
                   catch(Exception e)
                    {
                        ModelState.AddModelError(string.Empty, "Something went wrong Check the credentials you entered or try again later......");
                    }
                    var obj1 = (from n in db.Applicant_Details
                                               where n.Login_Id == LoginId
                                               select n.Applicant_Id).SingleOrDefault();
                    Session["Applicant Id"] = obj1;
                    if (applicant.Qualification == qual)
                    {
                        return RedirectToAction("_Nationald", "NationalEdu");
                    }
                    else
                    {
                        return RedirectToAction("_Academicd", "Academic");
                    }

                }
                else
                {
                    ModelState.AddModelError(String.Empty, "You are not eligible for this Scholarship....Go through the Elibility Criteria");
                    return PartialView(applicant);
                }
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Enter the credentials in mentioned format");
                return PartialView(applicant);
            }
        }
        public ActionResult _Detailapplicant()
        {
            var obj = from n in db.Applicant_Details
                      where n.Applicant_Id == Convert.ToInt32(Session["Applicant Id"])
                      select n;
            return PartialView(obj);
        }
        public ActionResult _viewstat()
        {
            int Appid = Convert.ToInt32(Session["Applicant Id"]);
            var obj = (from n in db.RegScheme_details
                       where n.Applicant_ID == Appid
                       select n).SingleOrDefault();
    if(obj.Funded_amt==null)
            {
                obj.Funded_amt = 0;
            }
   
            return PartialView(obj);
        }
    }
}
