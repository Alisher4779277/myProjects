using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qabulxona.Models;
using System.Text;
using Qabulxona.Models.Class;
using System.Drawing.Imaging;

namespace Qabulxona.Controllers
{
    public class HomeController : Controller
    {
        qabulxonaEntities1 db = new qabulxonaEntities1();
        public ActionResult Captcha()
        {
          
            string code = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            Session["code"] = code;
            CaptchaImage captcha = new CaptchaImage(code, 100, 50);

            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            captcha.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            captcha.Dispose();
            return null;
        }
        public ActionResult Index()
        {
            Session["Lang"] = 1;

            Info info = new Info();

            return View(info);
        }
        [HttpPost]
        public ActionResult Index(Info info, HttpPostedFileBase File)
        {
            //if (ModelState.IsValid)
            {
                if (info.Captcha == Session["code"].ToString())
                {
                    Requests req = new Requests();
                    Persons per = new Persons();

                    per.PersonName = info.Name;
                    per.YearOfBirth = info.YearOfBirth;
                    per.RegionId = info.Region;
                    per.AreaId = info.Area;
                    per.SexId = info.Sex;
                    per.Adress = info.Adress;
                    per.Phone = info.Phone;
                    per.Email = info.Email;

                    db.Persons.Add(per);
                    db.SaveChanges();

                    //int length = 10;
                    //const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-/";
                    //StringBuilder num = new StringBuilder();
                    //StringBuilder pas = new StringBuilder();
                    //Random rnd = new Random();
                    //while (0 < length--)
                    //{
                    //    num.Append(valid[rnd.Next(valid.Length)]);
                    //    pas.Append(valid[rnd.Next(valid.Length)]);
                    //}
                    int length = 5;
                    const string valid = "1234567890";
                    //StringBuilder num = new StringBuilder();
                    StringBuilder pas = new StringBuilder();
                    Random rnd = new Random();
                    while (0 < length--)
                    {
                        //num.Append(valid[rnd.Next(valid.Length)]);
                        pas.Append(valid[rnd.Next(valid.Length)]);
                    }
                    const string valid1 = "abcdefghijklmnopqrstuvwxyz";
                    length = 1;
                    while (0 < length--)
                    {
                        //num.Append(valid1[rnd.Next(valid.Length)]);
                        pas.Append(valid1[rnd.Next(valid.Length)]);
                    }

                    req.PersonId = per.PersonId;
                    req.RequestSubject = info.RequestSubject;
                    req.RequestShortText = info.ShortText;
                    req.RequestText = info.Text;
                    //req.RequestNumber = num.ToString();
                    req.RequestPassword = pas.ToString();
                    req.RequestStatusId = 1;
                    req.InComeDate = DateTime.Now;

                    db.Requests.Add(req);
                    db.SaveChanges();

                    switch (info.RequestSubject)
                    {
                        case "1": info.RequestSubject = "A"; break;
                        case "2": info.RequestSubject = "S"; break;
                        case "3": info.RequestSubject = "T"; break;
                    }
                    req.RequestNumber = req.RequestId + "/" + info.RequestSubject;
                    db.Entry(req);
                    db.SaveChanges();

                    if (File != null)
                    {
                        string fileName = System.IO.Path.GetFileName(req.RequestId + "_" + File.FileName);
                        File.SaveAs(Server.MapPath("~/Models/Files/" + fileName));
                        req.RequestFile = fileName;
                    }

                    db.Entry(req);
                    db.SaveChanges();

                    return RedirectToAction("About", new { num = req.RequestNumber, pas = req.RequestPassword });
                }

                return View();
            }

          // return View();
        }
        public ActionResult About(string num, string pas)
        {
            ViewBag.num = num;
            ViewBag.pas = pas;

            return View();
        }
        public ActionResult Contact()
        {
            Info info = new Info();

            return View(info);
        }
        [HttpPost]
        public ActionResult Contact(Info info)
        {
            if (info.Captcha == Session["code"].ToString())
            {
                try
                {
                    long req = db.Requests.FirstOrDefault(m => m.RequestNumber == info.RequestNumber && m.RequestPassword == info.RequestPassword).RequestId;
                    string numb = info.RequestNumber;
                    string pass = info.RequestPassword;
                    return RedirectToAction("Result", new { id = req, num = numb, pas = pass });
                }
                catch
                {
                    return RedirectToAction("Error");
                }
            }

            return View();
        }
        public ActionResult Result(int id, string num, string pas)
        {
            int? st = 0;
            try
            {
                ViewBag.num = db.Requests.FirstOrDefault(m => m.RequestId == id && m.RequestNumber == num && m.RequestPassword == pas).RequestNumber;
                ViewBag.statusId = db.Requests.FirstOrDefault(m => m.RequestId == id && m.RequestNumber == num && m.RequestPassword == pas).RequestStatusId;
                st = db.Requests.FirstOrDefault(m => m.RequestId == id && m.RequestNumber == num && m.RequestPassword == pas).RequestStatusId;
                try
                {
                    Requests req = db.Requests.FirstOrDefault(m => m.RequestId == id && m.RequestNumber == num && m.RequestPassword == pas);
                    req.LastVisit = DateTime.Now;
                    db.Entry(req);
                    db.SaveChanges();
                }
                catch { }
                if (st == 4 || st == 5)
                {
                    ViewBag.status = db.RequestStatuses.FirstOrDefault(m => m.StatusId == 2).StatusNameRu;
                    //ViewBag.Structure = db.Users.FirstOrDefault(m=>m.UserId == db.Answers.FirstOrDefault(x=>x.RequestId == id).UserId).UserName;
                }
                else
                {
                    ViewBag.status = db.RequestStatuses.FirstOrDefault(m => m.StatusId == st).StatusNameRu;
                    //ViewBag.Structure = db.Users.FirstOrDefault(m => m.UserId == db.Answers.FirstOrDefault(x => x.RequestId == id).UserId).UserName;
                }
            }
            catch
            {
                ViewBag.status = "Обращение не найдено";
            }
            if (st == 3)
            {
                try
                {
                    ViewBag.File = db.Answers.FirstOrDefault(m => m.RequestId == id).AnswerFile;
                    ViewBag.Text = db.Answers.FirstOrDefault(m => m.RequestId == id).AnswerText;
                }
                catch
                {
                    ViewBag.File = "";
                    ViewBag.Text = "";

                }
            }
            return View();
        }
        public ActionResult IndexUz()
        {
            Session["Lang"] = 2;

            Info info = new Info();

            return View(info);
        }
        [HttpPost]
        public ActionResult IndexUz(Info info, HttpPostedFileBase File)
        {
            //if (ModelState.IsValid)
            {
                if (info.Captcha == Session["code"].ToString())
                {
                    Requests req = new Requests();
                    Persons per = new Persons();

                    per.PersonName = info.Name;
                    per.YearOfBirth = info.YearOfBirth;
                    per.RegionId = info.Region;
                    per.AreaId = info.Area;
                    per.SexId = info.Sex;
                    per.Adress = info.Adress;
                    per.Phone = info.Phone;
                    per.Email = info.Email;

                    db.Persons.Add(per);
                    db.SaveChanges();

                    int length = 5;
                    const string valid = "1234567890";
                    //StringBuilder num = new StringBuilder();
                    StringBuilder pas = new StringBuilder();
                    Random rnd = new Random();
                    while (0 < length--)
                    {
                        //num.Append(valid[rnd.Next(valid.Length)]);
                        pas.Append(valid[rnd.Next(valid.Length)]);
                    }
                    const string valid1 = "abcdefghijklmnopqrstuvwxyz";
                    length = 1;
                    while (0 < length--)
                    {
                        //num.Append(valid1[rnd.Next(valid.Length)]);
                        pas.Append(valid1[rnd.Next(valid.Length)]);
                    }

                    req.PersonId = per.PersonId;
                    req.RequestSubject = info.RequestSubject;
                    req.RequestShortText = info.ShortText;
                    req.RequestText = info.Text;
                    //req.RequestNumber = num.ToString();
                    req.RequestPassword = pas.ToString();
                    req.RequestStatusId = 1;
                    req.InComeDate = DateTime.Now;

                    db.Requests.Add(req);
                    db.SaveChanges();

                    switch(info.RequestSubject)
                    {
                        case "1": info.RequestSubject = "A"; break;
                        case "2": info.RequestSubject = "S"; break;
                        case "3": info.RequestSubject = "T"; break;
                    }
                    req.RequestNumber = req.RequestId + "/" + info.RequestSubject;
                    db.Entry(req);
                    db.SaveChanges();

                    if (File != null)
                    {
                        string fileName = System.IO.Path.GetFileName(req.RequestId + "_" + File.FileName);
                        File.SaveAs(Server.MapPath("~/Models/Files/" + fileName));
                        req.RequestFile = fileName;
                    }

                    db.Entry(req);
                    db.SaveChanges();

                    return RedirectToAction("AboutUz", new { num = req.RequestNumber, pas = req.RequestPassword });
                }

                return View();
            }

           // return View();
        }
        public ActionResult AboutUz(string num, string pas)
        {
            ViewBag.num = num;
            ViewBag.pas = pas;

            return View();
        }
        public ActionResult ContactUz()
        {
            Info info = new Info();

            return View(info);
        }
        [HttpPost]
        public ActionResult ContactUz(Info info)
        {
            if (info.Captcha == Session["code"].ToString())
            {
                try
                {
                    long req = db.Requests.FirstOrDefault(m => m.RequestNumber == info.RequestNumber && m.RequestPassword == info.RequestPassword).RequestId;
                    string numb = info.RequestNumber;
                    string pass = info.RequestPassword;
                    return RedirectToAction("ResultUz", new { id = req, num = numb, pas = pass });
                }
                catch
                {
                    return RedirectToAction("ErrorUz");
                }
            }
            return View();
        }
        public ActionResult ResultUz(int id, string num, string pas)
        {
            int? st = 0;
            try
            {
                ViewBag.num = db.Requests.FirstOrDefault(m => m.RequestId == id && m.RequestNumber == num && m.RequestPassword == pas).RequestNumber;
                ViewBag.statusId = db.Requests.FirstOrDefault(m => m.RequestId == id && m.RequestNumber == num && m.RequestPassword == pas).RequestStatusId;
                st = db.Requests.FirstOrDefault(m => m.RequestId == id && m.RequestNumber == num && m.RequestPassword == pas).RequestStatusId;
                try
                {
                    Requests req = db.Requests.FirstOrDefault(m => m.RequestId == id && m.RequestNumber == num && m.RequestPassword == pas);
                    req.LastVisit = DateTime.Now;
                    db.Entry(req);
                    db.SaveChanges();
                }
                catch { }
                if (st == 4 || st == 5)
                {
                    ViewBag.status = db.RequestStatuses.FirstOrDefault(m => m.StatusId == 2).StatusNameUzk;
                    //ViewBag.Structure = db.Users.FirstOrDefault(m => m.UserId == db.Answers.FirstOrDefault(x => x.RequestId == id).UserId).UserName;
                }
                else
                {
                    ViewBag.status = db.RequestStatuses.FirstOrDefault(m => m.StatusId == st).StatusNameUzk;
                    //ViewBag.Structure = db.Users.FirstOrDefault(m => m.UserId == db.Answers.FirstOrDefault(x => x.RequestId == id).UserId).UserName;
                }
            }
            catch
            {
                ViewBag.status = "Мурожаат топилмади";
            }
            if (st == 3)
            {
                try
                {
                    ViewBag.File = db.Answers.FirstOrDefault(m => m.RequestId == id).AnswerFile;
                    ViewBag.Text = db.Answers.FirstOrDefault(m => m.RequestId == id).AnswerText;
                }
                catch
                {
                    ViewBag.File = "";
                    ViewBag.Text = "";
                }
            }
            return View();
        }
    }
}