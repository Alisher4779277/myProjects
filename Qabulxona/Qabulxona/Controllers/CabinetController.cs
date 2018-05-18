using Qabulxona.Models;
using Qabulxona.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Words;

namespace Qabulxona.Controllers
{
    public class CabinetController : Controller
    {
        qabulxonaEntities1 db = new qabulxonaEntities1();
        public ActionResult Index()
        {
            // return RedirectToAction("login", "account");
            return View();
        }
        public ActionResult IndexNew()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");
            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            IEnumerable<NewRequests_Result> requests = db.NewRequests(1).OrderBy(m => m.InComeDate);

            Session["url"] = "Cabinet/IndexNew";
            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {

                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(requests);

        }
        public ActionResult IndexOld()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            IEnumerable<OpenRequests_Result> requests = db.OpenRequests(1).OrderBy(m => m.InComeDate);

            Session["url"] = "Cabinet/IndexOld";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {

                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(requests);


        }
        public ActionResult IndexClosed()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            IEnumerable<CloseRequests_Result> requests = db.CloseRequests(1).OrderBy(m => m.InComeDate);

            Session["url"] = "Cabinet/IndexClosed";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {

                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(requests);


        }
        public ActionResult IndexRetweet()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            IEnumerable<RetweetRequests_Result> answers = db.RetweetRequests();

            Session["url"] = "Cabinet/IndexRetweet";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {

                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent =0;

            }
            return View(answers);


        }
        public ActionResult IndexOk()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            IEnumerable<CompleteRequests_Result> answers = db.CompleteRequests();

            Session["url"] = "Cabinet/IndexOk";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {

                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(answers);


        }
        public ActionResult Details(int id)
        {

            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            // Requests requests = db.Requests.FirstOrDefault(m => m.RequestId == id);
            Requests requests = db.Requests.FirstOrDefault(m => m.RequestId == id);
            Persons person = db.Persons.FirstOrDefault(m => m.PersonId == requests.PersonId);
            ViewBag.Region = db.Regions.FirstOrDefault(m => m.RegionId == person.RegionId).RegionNameUzk;
            ViewBag.Area = db.Areas.FirstOrDefault(m => m.AreaId == person.AreaId).AreaNameUzk;
            ViewBag.Sex = db.Sexs.FirstOrDefault(m => m.SexId == person.SexId).SexNameUzk;
            ViewBag.Status = db.RequestStatuses.FirstOrDefault(m => m.StatusId == requests.RequestStatusId).StatusNameUzk;
            

            try
            {
                long? x = db.Answers.FirstOrDefault(m => m.RequestId == id).AnswerId;
                Answers answ = db.Answers.FirstOrDefault(m => m.RequestId == id);
                if ((int)Session["User"] != 1)
                {
                    if (answ.UserReadDate == null)
                    {
                        answ.UserReadDate = DateTime.Now;
                        db.Entry(answ);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                Answers answer = new Answers();
                answer.RequestId = id;
                answer.UserId = 1;
                answer.DaysToSolve = DateTime.Now.AddDays(14);
                answer.ReadDate = DateTime.Now;
                answer.AnswerStatus = 1;

                db.Answers.Add(answer);
                db.SaveChanges();
            }

            try
            {
                ViewBag.FileName = requests.RequestFile;
            }
            catch
            {
                ViewBag.FileName = "";
            }
            try
            {
                ViewBag.OtvetFile = db.Answers.FirstOrDefault(m => m.RequestId == id).AnswerFile;
                ViewBag.OtvetText = db.Answers.FirstOrDefault(m => m.RequestId == id).AnswerText;
            }
            catch
            {
                ViewBag.OtvetFile = "";
                ViewBag.OtvetText = "";

            }
            try
            {
                ViewBag.VFileName = db.Answers.FirstOrDefault(m => m.RequestId == id).VisaFile;
            }
            catch
            {
                ViewBag.VFileName = "";
            }
            if (requests.RequestStatusId == 1)
            {
                requests.RequestStatusId = 2;
            }

            ViewBag.Url = Session["url"];
            Session["urll"] = "Cabinet/Details/" + requests.RequestId;

            db.Entry(requests);
            db.SaveChanges();
            return View(requests);


        }
        public ActionResult Answer(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            ViewBag.Url = Session["urll"];
            return View(id);
        }
        [HttpPost]
        public ActionResult Answer(int id, HttpPostedFileBase File, string text)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            Requests requests = db.Requests.FirstOrDefault(m => m.RequestId == id);
            Answers ans = db.Answers.FirstOrDefault(m => m.RequestId == id);
            if (db.Answers.FirstOrDefault(m => m.RequestId == id).UserId == 1)
                requests.ClosedDate = DateTime.Now;
            else
            {
                ans.UserAnswDate = DateTime.Now;
                db.Entry(ans);
            }
            if (Convert.ToInt32(Session["User"]) == 1)
            {
                requests.RequestStatusId = 3;
            }
            else
            {
                requests.RequestStatusId = 5;
            }
            db.Entry(requests);
            db.SaveChanges();

            Answers answ = db.Answers.FirstOrDefault(m => m.RequestId == requests.RequestId);

            if (File != null)
            {
                string fileName = System.IO.Path.GetFileName(requests.RequestId + File.FileName);
                File.SaveAs(Server.MapPath("~/Models/Files/" + fileName));
                answ.AnswerFile = fileName;
            }
            try
            {
                answ.AnswerText = text;
            }
            catch
            {

            }

            db.Entry(answ);
            db.SaveChanges();

            if (Convert.ToInt32(Session["User"]) == 1)
            {
                return RedirectToAction("IndexNew", "Cabinet");
            }
            else
            {
                return RedirectToAction("OpenRetweetRequests", "Cabinet");
            }

        }
        public ActionResult Retweet(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.Url = Session["urll"];
            Info info = new Info();
            return View(info);
        }
        [HttpPost]
        public ActionResult Retweet(Info info, int id, HttpPostedFileBase VisaFile)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            Requests req = db.Requests.FirstOrDefault(m => m.RequestId == id);
            req.RequestStatusId = 4;
            db.Entry(req);
            db.SaveChanges();

            Answers answ = db.Answers.FirstOrDefault(m => m.RequestId == id);
            answ.UserId = info.User;
            answ.DaysToSolve = answ.ReadDate.Value.AddDays(info.DaysToSolve);
            answ.AnswerComment = info.Comment;

            if (VisaFile != null)
            {
                string fileName = System.IO.Path.GetFileName("v" + "_" + req.RequestId + "_" + VisaFile.FileName);
                VisaFile.SaveAs(Server.MapPath("~/Models/Files/" + fileName));
                answ.VisaFile = fileName;
            }

            //if (answ.AnswerStatus == 1)
            //{
            //    answ.AnswerStatus = 0;
            //    db.Entry(answ);
            //    db.SaveChanges();
            //    answ.AnswerStatus = 1;
            //    answ.AnswerFile = null;
            //    answ.AnswerText = null;
            //    db.Answers.Add(answ);
            //}

            db.Entry(answ);
            db.SaveChanges();

            return RedirectToAction("Home");

        }
        public ActionResult SuccessRequest(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            Requests req = db.Requests.FirstOrDefault(m => m.RequestId == id);
            req.RequestStatusId = 3;
            req.ClosedDate = DateTime.Now;
            db.Entry(req);
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        public ActionResult OpenRetweetRequests()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<OpenRetweetRequests_Result> req = db.OpenRetweetRequests(Convert.ToInt32(Session["User"]));
            Session["url"] = "Cabinet/OpenRetweetRequests";
            return View(req);
        }
        public ActionResult CloseCompleteRequests()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<CloseCompleteRequests_Result> req = db.CloseCompleteRequests(Convert.ToInt32(Session["User"]));
            Session["url"] = "Cabinet/CloseCompleteRequests";
            return View(req);
        }
        public ActionResult CloseRequestsForOthers()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<CloseRequestsForOthers_Result> req = db.CloseRequestsForOthers(Convert.ToInt32(Session["User"]));
            Session["url"] = "Cabinet/CloseRequestsForOthers";
            return View(req);
        }
        public ActionResult Soon1()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<Soon1_Result> req = db.Soon1();
            Session["url"] = "Cabinet/Soon1";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();
            try
            {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();

            }
            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }

            return View(req);
        }
        public ActionResult Soon1_3()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<Soon1_3_Result> req = db.Soon1_3();
            Session["url"] = "Cabinet/Soon1_3";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();
            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;
            }
            return View(req);
        }
        public ActionResult Soon4_7()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<Soon4_7_Result> req = db.Soon4_7();
            Session["url"] = "Cabinet/Soon4_7";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();
            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }
            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult TotalExpired()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<TotalExpired_Result> req = db.TotalExpired();
            Session["url"] = "Cabinet/TotalExpired";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();
            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Expired1_3()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<expired1_3_Result> req = db.expired1_3();
            Session["url"] = "Cabinet/Expired1_3";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();
            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }
            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Expired3_5()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<expired3_5_Result> req = db.expired3_5();
            Session["url"] = "Cabinet/Expired3_5";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();
            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Expired5_10()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<expired5_10_Result> req = db.expired5_10();
            Session["url"] = "Cabinet/Expired5_10";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Expired10_()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<expired10__Result> req = db.expired10_();
            Session["url"] = "Cabinet/Expired10_";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();
            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Soon1ForIspol()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<Soon1ForIspol_Result> req = db.Soon1ForIspol();
            Session["url"] = "Cabinet/Soon1ForIspol";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Soon2ForIspol()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<Soon2ForIspol_Result> req = db.Soon2ForIspol();
            Session["url"] = "Cabinet/Soon2ForIspol";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Soon3ForIspol()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<Soon3ForIspol_Result> req = db.Soon3ForIspol();
            Session["url"] = "Cabinet/Soon3ForIspol";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult TotalExpiredForIspol()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<TotalExpiredForIspol_Result> req = db.TotalExpiredForIspol();
            Session["url"] = "Cabinet/TotalExpiredForIspol";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Expired1_3ForIspol()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<expired1_3ForIspol_Result> req = db.expired1_3ForIspol();
            Session["url"] = "Cabinet/Expired1_3ForIspol";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {

                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Expired3_5ForIspol()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<expired3_5ForIspol_Result> req = db.expired3_5ForIspol();
            Session["url"] = "Cabinet/Expired3_5ForIspol";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Expired5_10ForIspol()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<expired5_10ForIspol_Result> req = db.expired5_10ForIspol();
            Session["url"] = "Cabinet/Expired5_10ForIspol";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }
        public ActionResult Expired10_ForIspol()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            IEnumerable<expired10_ForIspol_Result> req = db.expired10_ForIspol();
            Session["url"] = "Cabinet/Expired10_ForIspol";

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }

            catch
            {

                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;

            }
            return View(req);
        }



        public ActionResult Home()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            ViewBag.Total = db.Requests.Count();
            ViewBag.New = db.Requests.Where(m => m.RequestStatusId == 1).Count();
            ViewBag.Open = db.Requests.Where(m => m.RequestStatusId == 2).Count();
            ViewBag.Close = db.Requests.Where(m => m.RequestStatusId == 3).Count();
            ViewBag.Retweet = db.Requests.Where(m => m.RequestStatusId == 4).Count();
            ViewBag.Complete = db.Requests.Where(m => m.RequestStatusId == 5).Count();

            try
            {
                ViewBag.NewProcent = db.Requests.Where(m => m.RequestStatusId == 1).Count() * 100 / db.Requests.Count();
                ViewBag.OpenProcent = db.Requests.Where(m => m.RequestStatusId == 2).Count() * 100 / db.Requests.Count();
                ViewBag.CloseProcent = db.Requests.Where(m => m.RequestStatusId == 3).Count() * 100 / db.Requests.Count();
                ViewBag.RetweetProcent = db.Requests.Where(m => m.RequestStatusId == 4).Count() * 100 / db.Requests.Count();
                ViewBag.CompleteProcent = db.Requests.Where(m => m.RequestStatusId == 5).Count() * 100 / db.Requests.Count();
            }
            catch
            {
                ViewBag.NewProcent = 0;
                ViewBag.OpenProcent = 0;
                ViewBag.CloseProcent = 0;
                ViewBag.RetweetProcent = 0;
                ViewBag.CompleteProcent = 0;
            }

            ViewBag.TotalMonth = db.Requests.Where(m => m.InComeDate.Value.Month == DateTime.Now.Month).Count();
            ViewBag.CloseMonth = db.Requests.Where(m => m.ClosedDate.Value.Month == DateTime.Now.Month && m.RequestStatusId == 3).Count();
            ViewBag.OpenMonth = db.Requests.Where(m => m.InComeDate.Value.Month == DateTime.Now.Month && (m.RequestStatusId == 2 || m.RequestStatusId == 1)).Count();
            ViewBag.RetweetMonth = db.Requests.Where(m => m.InComeDate.Value.Month == DateTime.Now.Month && m.RequestStatusId == 4).Count();
            ViewBag.CompleteMonth = db.Requests.Where(m => m.InComeDate.Value.Month == DateTime.Now.Month && m.RequestStatusId == 5).Count();

            ViewBag.TotalWeek = db.Requests.Where(m => m.InComeDate.Value.Day >= DateTime.Now.Day - 7).Count();
            ViewBag.CloseWeek = db.Requests.Where(m => m.ClosedDate.Value.Day >= DateTime.Now.Day - 7 && m.RequestStatusId == 3).Count();
            ViewBag.OpenWeek = db.Requests.Where(m => m.InComeDate.Value.Day >= DateTime.Now.Day - 7 && (m.RequestStatusId == 2 || m.RequestStatusId == 1)).Count();
            ViewBag.RetweetWeek = db.Requests.Where(m => m.InComeDate.Value.Day >= DateTime.Now.Day - 7 && m.RequestStatusId == 4).Count();
            ViewBag.CompleteWeek = db.Requests.Where(m => m.InComeDate.Value.Day >= DateTime.Now.Day - 7 && m.RequestStatusId == 5).Count();

            ViewBag.monday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 7).Count();
            ViewBag.tuesday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 6).Count();
            ViewBag.wednesday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 5).Count();
            ViewBag.touthday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 4).Count();
            ViewBag.friday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 3).Count();
            ViewBag.saturday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 2).Count();
            ViewBag.sunday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 1).Count();
            ViewBag.today = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day).Count();
            ViewBag.monday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 7 && m.RequestStatusId == 3).Count();
            ViewBag.tuesday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 6 && m.RequestStatusId == 3).Count();
            ViewBag.wednesday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 5 && m.RequestStatusId == 3).Count();
            ViewBag.touthday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 4 && m.RequestStatusId == 3).Count();
            ViewBag.friday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 3 && m.RequestStatusId == 3).Count();
            ViewBag.saturday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 2 && m.RequestStatusId == 3).Count();
            ViewBag.sunday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 1 && m.RequestStatusId == 3).Count();
            ViewBag.today1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day && m.RequestStatusId == 3).Count();

            ViewBag.DateSoon1 = db.ReqStatistic().FirstOrDefault().soon1;
            ViewBag.DateSoon3 = db.ReqStatistic().FirstOrDefault().soon1_3;
            ViewBag.DateSoon5 = db.ReqStatistic().FirstOrDefault().soon3_5;
            ViewBag.DateOutTotal = db.ReqStatistic().FirstOrDefault().totalExpired;
            ViewBag.DateOut3 = db.ReqStatistic().FirstOrDefault().expired1_3;
            ViewBag.DateOut5 = db.ReqStatistic().FirstOrDefault().expired3_5;
            ViewBag.DateOut10 = db.ReqStatistic().FirstOrDefault().expired5_10;
            ViewBag.DateOut15 = db.ReqStatistic().FirstOrDefault().expired10_;

            ViewBag.DateSoon1ForIspol = db.ReqStatistic().FirstOrDefault().soon1forispol;
            ViewBag.DateSoon2ForIspol = db.ReqStatistic().FirstOrDefault().soon2forispol;
            ViewBag.DateSoon3ForIspol = db.ReqStatistic().FirstOrDefault().soon3forispol;
            ViewBag.DateOutTotalForIspol = db.ReqStatistic().FirstOrDefault().totalExpiredforispol;
            ViewBag.DateOut3ForIspol = db.ReqStatistic().FirstOrDefault().expired1_3forispol;
            ViewBag.DateOut5ForIspol = db.ReqStatistic().FirstOrDefault().expired3_5forispol;
            ViewBag.DateOut10ForIspol = db.ReqStatistic().FirstOrDefault().expired5_10forispol;
            ViewBag.DateOut15ForIspol = db.ReqStatistic().FirstOrDefault().expired10_forispol;

            return View();
        }
        public ActionResult Statistic()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            int id = Convert.ToInt32(Session["User"]);


            ViewBag.monday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 7 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.tuesday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 6 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.wednesday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 5 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.touthday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 4 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.friday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.saturday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 2 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.sunday = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day - 1 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.today = db.Requests.Where(m => m.InComeDate.Value.Day == DateTime.Now.Day && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.monday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 7 && m.RequestStatusId == 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.tuesday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 6 && m.RequestStatusId == 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.wednesday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 5 && m.RequestStatusId == 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.touthday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 4 && m.RequestStatusId == 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.friday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 3 && m.RequestStatusId == 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.saturday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 2 && m.RequestStatusId == 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.sunday1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day - 1 && m.RequestStatusId == 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();
            ViewBag.today1 = db.Requests.Where(m => m.ClosedDate.Value.Day == DateTime.Now.Day && m.RequestStatusId == 3 && m.RequestId == db.Answers.Where(x => x.UserId == id).FirstOrDefault().RequestId).Count();

            ViewBag.Total = db.ReqStatUser(id).FirstOrDefault().total;
            ViewBag.New = db.ReqStatUser(id).FirstOrDefault().@in;
            ViewBag.Open = db.ReqStatUser(id).FirstOrDefault().@out;
            ViewBag.Close = db.ReqStatUser(id).FirstOrDefault().closed;
            ViewBag.NewProcent = db.ReqStatUser(id).FirstOrDefault().inprocent;
            ViewBag.OpenProcent = db.ReqStatUser(id).FirstOrDefault().outprocent;
            ViewBag.CloseProcent = db.ReqStatUser(id).FirstOrDefault().closedprocent;
            ViewBag.TotalMonth = db.ReqStatUser(id).FirstOrDefault().totalmonth;
            ViewBag.CloseMonth = db.ReqStatUser(id).FirstOrDefault().closedmonth;
            ViewBag.OpenMonth = db.ReqStatUser(id).FirstOrDefault().outmonth;
            ViewBag.NewMonth = db.ReqStatUser(id).FirstOrDefault().inmonth;

            ViewBag.DateSoon1 = db.ReqStatUser(id).FirstOrDefault().soon1;
            ViewBag.DateSoon3 = db.ReqStatUser(id).FirstOrDefault().soon1_3;
            ViewBag.DateSoon5 = db.ReqStatUser(id).FirstOrDefault().soon3_5;
            ViewBag.DateOutTotal = db.ReqStatUser(id).FirstOrDefault().totalExpired;
            ViewBag.DateOut3 = db.ReqStatUser(id).FirstOrDefault().expired1_3;
            ViewBag.DateOut5 = db.ReqStatUser(id).FirstOrDefault().expired3_5;
            ViewBag.DateOut10 = db.ReqStatUser(id).FirstOrDefault().expired5_10;
            ViewBag.DateOut15 = db.ReqStatUser(id).FirstOrDefault().expired10_;
            return View();
        }
        public ActionResult Exit()
        {
            Session["Active"] = "0";
            return RedirectToAction("login", "account");
        }
        public ActionResult ChangePassword()
        {
            Password pas = new Password();
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Password pas)
        {
            int id = Convert.ToInt32(Session["User"]);
            try
            {
                Users tmp = db.Users.FirstOrDefault(m => m.UserId == id);
                if (tmp.UserPassword == pas.OldPassword)
                {
                    if (pas.NewPassword == pas.EqualPassword)
                    {
                        ModelState.AddModelError("", "Пароль изменён.");
                        tmp.UserPassword = pas.NewPassword;
                        db.Entry(tmp);
                        db.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Введенные пароли не совпадают.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Текущий пароль введен не верно.");
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            return View();
        }

        public ActionResult CreateResolution(int id)
        {
            Info info = new Info();
            info.id = id;
            info.Comment = "Ўрнатилган тартибда кўриб чиқиб, мурожаатчига асосланган жавоб йўллансин.";
            return View(info);
        }
        [HttpPost]
        public ActionResult CreateResolution(Info info)
        {
            Answers ans = db.Answers.FirstOrDefault(m => m.RequestId == info.id);
            string isp = "";
            string person = "";
            string date = Convert.ToDateTime(db.Answers.FirstOrDefault(m=>m.RequestId == info.id).ReadDate.Value.AddDays(info.DaysToSolve)).ToShortDateString();
            foreach(var item in info.ispol)
            {
                if (db.Users.FirstOrDefault(m => m.UserId == item).UserFullName == null)
                {
                    person += db.Users.FirstOrDefault(m => m.UserId == item).UserName + "\v";
                    isp += db.Users.FirstOrDefault(m => m.UserId == item).UserName + ", ";
                }
                else
                {
                    person += db.Users.FirstOrDefault(m => m.UserId == item).UserFullName + "\v";
                    isp += db.Users.FirstOrDefault(m => m.UserId == item).UserFullName + ", ";
                }
            }
            isp = isp.Substring(0, isp.Length - 2);
            ans.ispol = isp;
            ans.DaysToSolveForIspol = db.Answers.FirstOrDefault(m => m.RequestId == info.id).ReadDate.Value.AddDays(info.DaysToSolve);
            db.Entry(ans);
            db.SaveChanges();

            person = person.Substring(0, person.Length-1);
            string commint = info.Comment;
            return RedirectToAction("ExportRequest", new { id = info.id, date = date, person = person, commint = commint });
        }
        public ActionResult ExportRequest(int? id, string date, string person, string commint)
        {
            string FilePath = System.Web.HttpContext.Current.Server.MapPath("~/Models/Templates/");

            Document doc = new Document(FilePath + "Template.dotx");

            int xx = Convert.ToInt32(db.Requests.FirstOrDefault(m => m.RequestId == id).RequestSubject);
            doc.Range.Replace("daystosolve", date, false, true);
            doc.Range.Replace("persons", person, false, true);
            doc.Range.Replace("resol", commint, false, true);
            try
            {
                doc.Range.Replace("shorttext", db.Requests.FirstOrDefault(m => m.RequestId == id).RequestShortText, false, true);
            }
            catch
            {
                doc.Range.Replace("shorttext", "", false, true);
            }
            doc.Range.Replace("reqnum", db.Requests.FirstOrDefault(m => m.RequestId == id).RequestNumber + "-VQ", false, true);
            doc.Range.Replace("incomed", Convert.ToString(db.Requests.FirstOrDefault(m => m.RequestId == id).InComeDate), false, true);
            doc.Range.Replace("readd", Convert.ToString(db.Answers.FirstOrDefault(m => m.RequestId == id).ReadDate), false, true);
            doc.Range.Replace("reqtype", db.RequestSubjectTypes.FirstOrDefault(a=>a.RequestSubjectTypeID == xx).RequestSubjectNameUz, false, true);
            doc.Range.Replace("pername", db.Persons.FirstOrDefault(m => m.PersonId == db.Requests.FirstOrDefault(x => x.RequestId == id).PersonId).PersonName, false, true);
            doc.Range.Replace("adress", db.Persons.FirstOrDefault(m => m.PersonId == db.Requests.FirstOrDefault(x => x.RequestId == id).PersonId).Adress, false, true);
            doc.Range.Replace("phone", db.Persons.FirstOrDefault(m => m.PersonId == db.Requests.FirstOrDefault(x => x.RequestId == id).PersonId).Phone, false, true);
            try { doc.Range.Replace("email", db.Persons.FirstOrDefault(m => m.PersonId == db.Requests.FirstOrDefault(x => x.RequestId == id).PersonId).Email, false, true); } catch { doc.Range.Replace("email", "", false, true); }
            string str = db.Requests.FirstOrDefault(m => m.RequestId == id).RequestText;
            str = str.Replace("\n", " ");
            str = str.Replace("\t", " ");
            str = str.Replace("\r", " ");
            doc.Range.Replace("text", str, false, true);
            if (db.Answers.FirstOrDefault(m=>m.RequestId == id).UserId != 1) { doc.Range.Replace("user", db.Users.FirstOrDefault(m => m.UserId == db.Answers.FirstOrDefault(x => x.RequestId == id).UserId).UserName + "га", false, true); }
            else  { doc.Range.Replace("user", "", false, true); }
            try { doc.Range.Replace("resolution", db.Answers.FirstOrDefault(m => m.RequestId == id).AnswerComment, false, true); } catch { doc.Range.Replace("resolution", "", false, true); }
            try { doc.Range.Replace("datetosolve", db.Answers.FirstOrDefault(m => m.RequestId == id).DaysToSolve.ToString(), false, true); } catch { doc.Range.Replace("daysyosolve", "", false, true); }
            doc.Save(FilePath + "Document.Doc2PdfSave.doc");

            var ba = System.IO.File.ReadAllBytes(FilePath + "Document.Doc2PdfSave.doc");
            string filname = db.Requests.FirstOrDefault(m => m.RequestId == id).RequestNumber + "-VQ.doc";
            return File(ba, "application/octet-stream", filname); //Return to download file
        }
    }
}