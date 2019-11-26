using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class AdminViewerController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: AdminViewer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _AdminView()
        {
            try
            {
                var res = db.viewappl().SingleOrDefault();
                Session["Stud Id"] = res.Applicant_Id;
                return PartialView(res);
            }
            catch(Exception e)
            {
                ModelState.AddModelError(" ", "No Recent Application!!!");
                return RedirectToAction("_AdminView","pageview");
            }
        }
        public ActionResult _ViewVerifiedApp()
        {
            var res = db.verifiedappl().SingleOrDefault();
            
            return PartialView(res);
        }
        public ActionResult _Approved()
        {
            int amnt = 25000;
            int studId = Convert.ToInt32(Session["Stud Id"]);
            var obj = (from n in db.RegScheme_details
                       where n.Applicant_ID == studId
                       select n).SingleOrDefault();
            obj.App_status = "Accepted";
            obj.Funded_amt = amnt;
            obj.Payment_Status = "Under Progress";
            obj.Fund_transfer_date = DateTime.Today.AddDays(25);
            try
            {
                db.Regschadminn(studId, obj.App_status, obj.Payment_Status, amnt, obj.Fund_transfer_date);
                return RedirectToAction("Adminview", "pageview");
            }
            catch (Exception e)
            {
                return RedirectToAction("Adminview", "pageview");
            }
        }
            public ActionResult _Rejected()
            {
            int studId = Convert.ToInt32(Session["Stud Id"]);
            var obj = (from n in db.RegScheme_details
                       where n.Applicant_ID == studId
                       select n).SingleOrDefault();
            obj.App_status = "Rejected";
            try
            {
                db.RegSchAdRej(studId, obj.App_status);
                return RedirectToAction("Adminview", "pageview");
            }
            catch (Exception e)
            {
              ////////////////////ModelState.AddModelError("","Something Went Wrong!!!!");
                return RedirectToAction("Adminview", "pageview");
            }
        }


        }

    }
