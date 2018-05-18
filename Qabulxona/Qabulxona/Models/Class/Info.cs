using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qabulxona.Models
{
    public class Info
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Region { get; set; }
        [Required]
        public int? Area { get; set; }
        [Required]
        public string Adress { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int? Sex { get; set; }
        [Required]
        public int? Agree { get; set; }

        [Required]
        public string YearOfBirth { get; set; }
        public string File { get; set; }
        public string VisaFile { get; set; }
        [Required]
        public string RequestSubject { get; set; }
        [Required]
        public string ShortText { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Captcha { get; set; }
        public string RequestNumber { get; set; }
        public string RequestPassword { get; set; }
        public double DaysToSolve { get; set; }
        public string Comment { get; set; }
        public int User { get; set; }
        public int UserType { get; set; }
        public int UserFullName { get; set; }
        public int id { get; set; }

        public int[] ispol { get; set; }
        
    }
}