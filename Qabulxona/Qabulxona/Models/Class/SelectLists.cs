using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qabulxona.Models;

namespace Qabulxona
{
    public static class SelectLists
    {
        private static qabulxonaEntities1 db = new qabulxonaEntities1();

        public static List<SelectListItem> Regions(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.Regions, "RegionId", "RegionNameRu");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.Regions, "RegionId", "RegionNameUzk");
                list.Add(new SelectListItem { Text = "Танланг", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> Districts(int reg, int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.Areas.Where(m => m.RegionId == reg).OrderBy(s => s.AreaNameUzk), "AreaId", "AreaNameRu");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.Areas.Where(m => m.RegionId == reg).OrderBy(s => s.AreaNameUzk), "AreaId", "AreaNameUzk");
                list.Add(new SelectListItem { Text = "Танланг", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> Sexs(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.Sexs, "SexId", "SexNameRu");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.Sexs, "SexId", "SexNameUzk");
                list.Add(new SelectListItem { Text = "Танланг", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> Users(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.Users.Where(m=>m.UserId != 1 && m.UserTypeId != 3).OrderByDescending(m=>m.UserTypeId).ThenBy(m=>m.UserName), "UserId", "UserName");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.Users.Where(m => m.UserId != 1 && m.UserTypeId != 3).OrderByDescending(m => m.UserTypeId).ThenBy(m => m.UserName), "UserId", "UserName");
                list.Add(new SelectListItem { Text = "Танланг", Value = "" });
                list.AddRange(select);
            }
            if (lang == 3)
            {
                SelectList select = new SelectList(db.Users.Where(m => m.UserId != 1 && m.UserTypeId == 99).OrderByDescending(m => m.UserTypeId).ThenBy(m => m.UserName), "UserId", "UserName");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> UsersType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
            list.Add(new SelectListItem { Text = "Ички назоратга", Value = "1" });
            list.Add(new SelectListItem { Text = "Ташқи назоратга", Value = "2" });
            
            return list;
        }
        public static List<SelectListItem> UsersFullName(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
                SelectList select = new SelectList(db.Users.Where(m => m.UserId == id), "UserId", "UserFullName");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            return list;
        }
    }
}