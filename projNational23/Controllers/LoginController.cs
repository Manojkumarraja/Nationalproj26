using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projNational23.Models;
namespace projNational23.Controllers
{
    public class LoginController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signin(Login log)
        {
            if (ModelState.IsValid)
            {
              
                    var result = (from L in db.Login_Details
                                  where L.Login_Id == log.Login_Id
                                  && L.Password == log.Password
                                  select L).SingleOrDefault();
                try
                {
                    Session["Login Id"] = result.Login_Id;
                    Session["Name"] = result.Name;
                }
                catch(Exception e)
                {
                    Console.Write("Login Credential is Wrong");
                }
                if ((result != null) && (result.User_Type == "A"))
                {
                    //Session["Name"] = result.Name;
                    return RedirectToAction("Adminview","pageview");
                }
                else if (result != null)
                {

                    return RedirectToAction("_Applicantd", "Applicant");
                }
                else
                {
                    ModelState.AddModelError("", " Invalid Login Credentials \n Try Again...");
                    return View(log);
                }

            }
            else
            {
                ModelState.AddModelError("", " Invalid Login Credentials \n Try Again...");
                return View(log);
            }
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
