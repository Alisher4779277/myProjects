using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance_car.Models;

namespace Insurance_car
{
    public class AddSelectList
    {
        private static sugurtaEntities db = new sugurtaEntities();
        public static List<SelectListItem> Area(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Areas, "Id", "Name");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Event(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Event_Insurance, "Id", "Name");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> exper(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Experiences, "Id", "Year_Experience");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Term(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Term_Insurance, "Id", "Term");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Transport(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Transport_type, "Id", "Name");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> TypeUser(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Type_User, "Id", "Type_User");
            list.AddRange(select);
            return list;
        }

    }
}