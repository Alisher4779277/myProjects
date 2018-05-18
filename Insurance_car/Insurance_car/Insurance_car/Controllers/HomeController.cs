using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance_car.Models;

namespace Insurance_car.Controllers
{
    public class HomeController : Controller
    {
        public static bool isRegister = false;
        public static string name = "";
        sugurtaEntities db = new sugurtaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contactus()
        {
            Contact c = new Contact();
            c.Name = Convert.ToString(Request.Form["name"]);
            c.PhoneNumber = Convert.ToString(Request.Form["PhoneNumber"]);
            c.Message = Convert.ToString(Request.Form["message"]);

            db.Contacts.Add(c);
            db.SaveChanges();
            TempData["natija"] = " Hurmatli "+ c.Name+" sizning murojaatingiz qabul qilindi!!!";
            return RedirectToAction("Contact", "home");
        }

        public ActionResult Calculator()
        {
            return View();
        }

        public ActionResult portfolio()
        {
            return View();
        }
     

        public ActionResult services()
        {

            if (isRegister)
            {
                ViewBag.pp = " sizning sug'urtangiz ro'yhatdan o'tkazildi. Siz bilan tez orada bog'lanamiz!! Bizning hizmatlarimizdan foydalanganingiz uchun rahmat!!!"; isRegister = false;
                ViewBag.name = name;
                return View();
            }
            else
            {
                ViewBag.s = 0;
            return View();
           
            }
           
        }

        [HttpPost]
        public ActionResult services(Insurance insur)
        {

            double summa=0, k_tr=0, k_vz=0, k_msh = 0, k_ss =0,  k_sr=0, baz_stoim=0;

            k_tr = 2.2-(double)insur.Area_Id * 0.2;

            if (insur.Exper_Id == 1)
            {
                k_vz = (double)insur.Born * 1;
            }
            else if(insur.Exper_Id == 2) { k_vz = (double)insur.Born * 1.5; }
            else { k_vz = (double)insur.Born * 2; }

            k_msh = 2.2 - (Convert.ToDouble(insur.Transport_Id) * 0.1);

            // kss method gives you kss total it is up to your chooise
             //это коэффициент страховых случаев в которых 
            //Вы были виновником ДТП или нет. Если нет, то страховка обойдется Вам значительно дешевле.
            k_ss = kss(insur.Event_Id);

            // ksr method gives you ksr total sum it is up to your chooise
            //это коэффициент длительности срока страхования. Чем меньше срок страхования, тем дороже
            k_sr = ksr(insur.Term_Id);


           
            baz_stoim = (insur.Type_UserId==1)?1480 : (insur.Type_UserId==2)?2048:0;



            summa = k_tr * k_vz * k_ss * k_ss * k_msh * k_msh * k_sr * baz_stoim;
            summa = summa * 6;
            summa = Math.Round(summa, 2);
            ViewBag.Total = summa;
            insur.Date = DateTime.Now;
            ViewBag.s = 1;

            if (insur.Person_Name != null && insur.PhonoNumber != null && insur.Person_Address != null) {
                insur.Summary = Convert.ToInt32(summa);
                insur.State_Id = 1;
                db.Insurances.Add(insur);
                db.SaveChanges();
                isRegister = true;
                name = insur.Person_Name;
                return RedirectToAction("services", "home");
            }

            //db.Insurances.Add(insur);
            //db.SaveChanges();

            return View();
        }
  

        private double ksr(int? term_Id)
        {
            int month = (int)term_Id + 5;

            switch (month)
            {
                case 6: { return 1.30; }
                case 7: { return 1.20; }
                case 8: { return 1.10; }
                case 9: { return 1; }
                case 10: { return 0.95; }
                case 11: { return 0.80; }
                case 12: { return 0.70; }

                default: return 1;
              
            }

        }

        private double kss(int? event_Id)
        {
            switch (event_Id)
            {
                case 1: { return 0.95; }
                case 2: { return 0.90; }
                case 3: { return 0.80; }
                case 4: { return 0.70; }
                case 5: { return 0.60; }
                case 6: { return 0.50; }
                case 7: { return 1.10; }
                case 8: { return 1.20; }
                case 9: { return 1.40; }
                default: return 1;
                   
            }
        }
    }
}