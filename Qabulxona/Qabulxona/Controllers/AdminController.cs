using Qabulxona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qabulxona.Controllers
{
    public class AdminController : Controller
    {
        qabulxonaEntities1 db = new qabulxonaEntities1();

        public ActionResult IndexUz()
        {
            return RedirectToAction("login", "account");
        }
        public ActionResult IndexNew()
        {
            if (Session["Active"].ToString() == "1")
            {
                IEnumerable<Requests> requests = db.Requests.Where(m => m.RequestStatusId == 1).OrderBy(m => m.InComeDate);
                ViewBag.newquanty = db.Requests.Where(m => m.RequestStatusId == 1).Count();
                ViewBag.openquanty = db.Requests.Where(m => m.RequestStatusId == 2).Count();
                ViewBag.closequanty = db.Requests.Where(m => m.RequestStatusId == 3).Count();
                return View(requests);
            }
            else
            {
                return RedirectToAction("login", "account");
            }
        }
        public ActionResult IndexOld()
        {
            if (Session["Active"].ToString() == "1")
            {
                IEnumerable<Requests> requests = db.Requests.Where(m => m.RequestStatusId == 2).OrderBy(m => m.InComeDate);
                ViewBag.newquanty = db.Requests.Where(m => m.RequestStatusId == 1).Count();
                ViewBag.openquanty = db.Requests.Where(m => m.RequestStatusId == 2).Count();
                ViewBag.closequanty = db.Requests.Where(m => m.RequestStatusId == 3).Count();
                return View(requests);
            }
            else
            {
                return RedirectToAction("login", "account");
            }
            
        }
        public ActionResult IndexClosed()
        {
            if (Session["Active"].ToString() == "1")
            {
                IEnumerable<Requests> requests = db.Requests.Where(m => m.RequestStatusId == 3).OrderBy(m => m.InComeDate);
                ViewBag.newquanty = db.Requests.Where(m => m.RequestStatusId == 1).Count();
                ViewBag.openquanty = db.Requests.Where(m => m.RequestStatusId == 2).Count();
                ViewBag.closequanty = db.Requests.Where(m => m.RequestStatusId == 3).Count();
                return View(requests);
            }
            else
            {
                return RedirectToAction("login", "account");
            }
            
        }
        //public ActionResult Details(int id)
        //{
        //    if (Session["Active"].ToString() == "1")
        //    {
        //        Requests requests = db.Requests.FirstOrDefault(m => m.RequestId == id);
        //        ViewBag.Region = db.Regions.FirstOrDefault(m => m.RegionId == requests.RegionId).RegionNameRu;
        //        ViewBag.Area = db.Areas.FirstOrDefault(m => m.AreaId == requests.AreaId).AreaNameRu;
        //        ViewBag.Sex = db.Sexs.FirstOrDefault(m => m.SexId == requests.SexId).SexNameRu;
        //        ViewBag.Status = db.RequestStatuses.FirstOrDefault(m => m.StatusId == requests.RequestStatusId).StatusNameRu;
        //        try
        //        {
        //            ViewBag.FileName = db.Files.FirstOrDefault(m => m.RequestId == requests.RequestId).FileInName;
        //            ViewBag.FileMap = db.Files.FirstOrDefault(m => m.RequestId == requests.RequestId).FileInMapPath;
        //        }
        //        catch
        //        {
        //            ViewBag.FileName = "";
        //            ViewBag.FileMap = "";

        //        }
        //        if (requests.RequestStatusId != 3)
        //        {
        //            requests.RequestStatusId = 2;
        //        }
        //        db.Entry(requests);
        //        db.SaveChanges();
        //        return View(requests);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "account");
        //    }
            
        //}
        //public ActionResult Answer(int id)
        //{
        //    if (Session["Active"].ToString() == "1")
        //    {
        //        return View(id);
        //    }

        //    else
        //    {
        //        return RedirectToAction("login", "account");
        //    }
        //}    
        
        //[HttpPost]
        //public ActionResult Answer(int id, HttpPostedFileBase File, string text)
        //{
        //    if (Session["Active"].ToString() == "1")
        //    {
        //        Requests requests = db.Requests.FirstOrDefault(m => m.RequestId == id);
        //        requests.RequestStatusId = 3;
        //        db.Entry(requests);
        //        db.SaveChanges();

        //        Files file = new Files();

        //        file = db.Files.FirstOrDefault(m => m.RequestId == requests.RequestId);

        //        if (File != null)
        //        {
        //            string fileName = System.IO.Path.GetFileName(File.FileName);
        //            File.SaveAs(Server.MapPath("~/Models/Files/" + fileName));
        //            file.FileOutName = fileName;
        //            file.FileOutMapPath = Server.MapPath("~/Models/Files/" + fileName);
        //        }

        //        file.Text = text;

        //        db.Entry(file);
        //        db.SaveChanges();

        //        return RedirectToAction("IndexNew");
        //    }

        //    else
        //    {
        //        return RedirectToAction("login", "account");
        //    }
            
        //}
        public ActionResult Exit()
        {
            Session["Active"] = "0";
            return RedirectToAction("login", "account");
        }

    }
}