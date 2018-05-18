using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qabulxona.Models;

namespace Qabulxona
{
    public class JSonController : Controller
    {
        private qabulxonaEntities1 db;
        public JSonController()
        {
            db = new qabulxonaEntities1();
        }
        public JsonResult GetJsonArea(int id, int lang)
        {
            SelectList select = new SelectList(db.Areas);
            if (lang == 1)
            {
                select = new SelectList(db.Areas.Where(m => m.RegionId == id), "AreaId", "AreaNameRu");
                return Json(select, JsonRequestBehavior.AllowGet);
            }
            if (lang == 2)
            {
                select = new SelectList(db.Areas.Where(m => m.RegionId == id), "AreaId", "AreaNameUzk");
                
            }
            return Json(select, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetJsonUsers(int type)
        {
            MultiSelectList select = new SelectList(db.Users);
            if (type == 1)
            {
                select = new MultiSelectList(db.Users.Where(m => m.UserTypeId == 3).OrderBy(m=>m.UserFullName), "UserId", "UserFullName");

            }
            else if (type == 2)
            {
                select = new SelectList(db.Users.Where(m => m.UserTypeId == 2 || m.UserTypeId == 4).OrderByDescending(m=>m.UserTypeId), "UserId", "UserName");

            }
            return Json(select, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult GetJsonUsersFullName(int id)
        {
            SelectList select = new SelectList(db.Areas);
                select = new SelectList(db.Users.Where(m => m.UserId == id), "UserId", "UserFullName");
            return Json(select, JsonRequestBehavior.AllowGet);

        }
    }
}