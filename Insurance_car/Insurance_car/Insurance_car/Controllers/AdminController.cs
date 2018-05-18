using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance_car.Models;
using PagedList;

namespace Insurance_car.Controllers
{
    public class AdminController : Controller
    {
        sugurtaEntities db = new sugurtaEntities();
        // GET: Admin
        public ActionResult Index()
        {
            int keganla = 0, tasdiq = 0, beril = 0;
            int m_soni = db.Contacts.Count();
            foreach (var item in db.Insurances)
            {
                if (item.State_Id == 1)
                    keganla++;
                else if (item.State_Id == 2)
                    tasdiq++;
                else beril++;
            }

            ViewBag.m_soni = m_soni;
            ViewBag.keganla = keganla;
            ViewBag.tasdiq = tasdiq;
            ViewBag.beril = beril;

             

            return View(db.Insurances.ToList());
         
        }
        public ActionResult charts()
        {

  

            return View(db.Insurances.Where(x => x.State_Id == 1).OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult elements()
        {
            return View(db.Contacts.ToList());
        }
        public ActionResult panels()
        {
            
          

            return View(db.Insurances.Where(x => x.State_Id == 3).OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult widgets()
        {
         

            return View(db.Insurances.Where(x=>x.State_Id==2).OrderByDescending(x => x.Id).ToList());
        }

        public ActionResult Details(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public ActionResult Details(Insurance a)
        {
            Insurance aa = db.Insurances.FirstOrDefault(x => x.Id == a.Id);

            return View();     }

        public ActionResult Login()
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public ActionResult Delete(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Insurance i)
        {
            Insurance a = db.Insurances.FirstOrDefault(x => x.Id == i.Id);
            db.Insurances.Remove(a);
            db.SaveChanges();

            return RedirectToAction("Charts","Admin");
        }
    
        public ActionResult Success(int id)
        {
            Insurance ins = db.Insurances.FirstOrDefault(x => x.Id == id);

            if (ins.State_Id == 1)
            {
                ins.State_Id = 2;
            }
            else if(ins.State_Id == 2)
            {
                ins.State_Id = 3;
            }

            db.Entry(ins);
            db.SaveChanges();
            //db.Users.Remove(uu);
            //db.SaveChanges();

            if (ins.State_Id == 1)
            {
                return RedirectToAction("charts");
            }
            return RedirectToAction("widgets");
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            sugurtaEntities db = new sugurtaEntities();

            //CheckLogin_Result result = db.CheckLogin(model.Email, model.Password).FirstOrDefault();
            Users result = db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (result != null)
            {

                //if (result.Type == 2)
                //{
                //    ViewBag.Error = "Ваш профиль блокирован";
                //    return RedirectToAction("login", "account");
                //}

                Session["Active"] = "1";
                Session["User"] = result.ID;
                //Session["us"] = result.ID;
                //Session["Type"] = result.Type;

                if (Session["User"].ToString() == "1")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }

    }
}