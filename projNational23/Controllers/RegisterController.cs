using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class RegisterController : Controller
    {
        NationEntities db = new NationEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.con =true;
            return View();
        }

        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Register(Login_Details login_Details)
          {
            
            if(ModelState.IsValid)
            {
                if (Session["Name"] != null)
                {
                   
                        login_Details.User_Type = "A";
                        try
                        {
                            db.Login_Details.Add(login_Details);
                            db.SaveChanges();
                        }
                        catch(Exception e)
                        {
                            ModelState.AddModelError("", "Something Went Wrong Check the credentials entered or try again later.....");
                            return PartialView(login_Details);
                        }
                        return RedirectToAction("Adminview","pageview");
 
                }
                else
                {
                    login_Details.User_Type = "U";
                    try
                    {
                        db.Login_Details.Add(login_Details);
                        db.SaveChanges();
                        return RedirectToAction("_Applicantd", "Applicant");
                    }
                    catch(Exception e)
                    {
                        ModelState.AddModelError("", "Something Went Wrong Check the credentials entered or try again later.....");
                        return PartialView(login_Details);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Enter the Required Details Correctly...");
                return View(login_Details);
            }
        }

        }
    }