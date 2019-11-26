using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projNational23.Controllers
{
    public class Files3Controller : Controller
    {
        NationEntities db = new NationEntities();
        // GET: Files3
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Files3d()
        {
            int AppId = Convert.ToInt32(Session["Applicant Id"]);
            var ob1 = (from n in db.Applicant_Details where n.Applicant_Id == AppId select n).SingleOrDefault();
            var obj = (from n in db.Files3 where n.Applicant_Id == AppId select n).SingleOrDefault();
            if (obj != null)
            {
                return PartialView(obj);
            }
            else
                return RedirectToAction("_Files3");
        }
        public ActionResult _Files3()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult _Files3(Files3 s, HttpPostedFileBase ImagePhoto, HttpPostedFileBase ImageAadhar, HttpPostedFileBase ImageHSC, HttpPostedFileBase ImageSSC, HttpPostedFileBase ImageDegree, HttpPostedFileBase ImageNativity, HttpPostedFileBase ImageIncome, HttpPostedFileBase ImageCommunity)
        {
            s.Applicant_Id = Convert.ToInt32(Session["Applicant Id"]);
            try{ 
            string myfilename1 = Path.GetFileNameWithoutExtension(ImagePhoto.FileName);

            string extension1 = Path.GetExtension(ImagePhoto.FileName);

            myfilename1 = myfilename1 + extension1;
            s.Photo = "~/Images/Photo/" + myfilename1;
            myfilename1 = Path.Combine(Server.MapPath("~/Images/Photo/"), myfilename1);
            ImagePhoto.SaveAs(myfilename1);
            db.Files3.Add(s);


            string myfilename2 = Path.GetFileNameWithoutExtension(ImageAadhar.FileName);

            string extension2 = Path.GetExtension(ImageAadhar.FileName);

            myfilename2 = myfilename2 + extension2;
            s.Aadhar_Card = "~/Images/Aadhar/" + myfilename2;
            myfilename2 = Path.Combine(Server.MapPath("~/Images/Aadhar/"), myfilename2);
            ImageAadhar.SaveAs(myfilename2);
            db.Files3.Add(s);

            string myfilename3 = Path.GetFileNameWithoutExtension(ImageHSC.FileName);

            string extension3 = Path.GetExtension(ImageHSC.FileName);

            myfilename3 = myfilename3 + extension3;
            s.HSC_Marksheet = "~/Images/HSC/" + myfilename3;
            myfilename3 = Path.Combine(Server.MapPath("~/Images/HSC/"), myfilename3);
            ImageHSC.SaveAs(myfilename3);
            db.Files3.Add(s);


            string myfilename4 = Path.GetFileNameWithoutExtension(ImageSSC.FileName);

            string extension4 = Path.GetExtension(ImageSSC.FileName);
            myfilename4 = myfilename4 + extension4;
            s.SSC_MarkSheet = "~/Images/SSC/" + myfilename4;
            myfilename4 = Path.Combine(Server.MapPath("~/Images/SSC/"), myfilename4);
            ImageSSC.SaveAs(myfilename4);
            db.Files3.Add(s);

            string myfilename5 = Path.GetFileNameWithoutExtension(ImageDegree.FileName);

            string extension5 = Path.GetExtension(ImageDegree.FileName);
            myfilename5 = myfilename5 + extension5;
            s.Degree_Marksheet = "~/Images/Degree/" + myfilename5;
            myfilename5 = Path.Combine(Server.MapPath("~/Images/Degree/"), myfilename5);
            ImageDegree.SaveAs(myfilename5);
            db.Files3.Add(s);

            string myfilename6 = Path.GetFileNameWithoutExtension(ImageNativity.FileName);

            string extension6 = Path.GetExtension(ImageNativity.FileName);
            myfilename6 = myfilename6 + extension6;
            s.Nativity_Certificate = "~/Images/Nativity/" + myfilename6;
            myfilename6 = Path.Combine(Server.MapPath("~/Images/Nativity/"), myfilename6);
            ImageNativity.SaveAs(myfilename6);
            db.Files3.Add(s);

            string myfilename7 = Path.GetFileNameWithoutExtension(ImageIncome.FileName);

            string extension7 = Path.GetExtension(ImageIncome.FileName);
            myfilename7 = myfilename7 + extension7;
            s.Income_Certificate = "~/Images/Income/" + myfilename7;
            myfilename7 = Path.Combine(Server.MapPath("~/Images/Income/"), myfilename7);
            ImageIncome.SaveAs(myfilename7);
            db.Files3.Add(s);

            string myfilename8 = Path.GetFileNameWithoutExtension(ImageCommunity.FileName);

            string extension8 = Path.GetExtension(ImageCommunity.FileName);
            myfilename8 = myfilename8 + extension8;
            s.Community_Certificate = "~/Images/Community/" + myfilename8;
            myfilename8 = Path.Combine(Server.MapPath("~/Images/Community/"), myfilename8);
            ImageCommunity.SaveAs(myfilename8);
            db.Files3.Add(s);
            db.SaveChanges();
            int AppId = Convert.ToInt32(Session["Applicant Id"]);
            var obj = (from n in db.RegScheme_details
                       where n.Applicant_ID == AppId
                       select n).SingleOrDefault();
                obj.App_status = "Application Received";
                obj.Payment_Status = "Pending";
                obj.Funded_amt = 0;

                db.Regschstud(s.Applicant_Id, obj.App_status, obj.Payment_Status, obj.Funded_amt);
            db.SaveChanges();
        }
            catch(Exception e)
            {

                ModelState.AddModelError("", "Something went wrong Check the credentials you entered or try again later......");
                return PartialView();
            }
            return RedirectToAction("_Files3d");
        }
    }
}