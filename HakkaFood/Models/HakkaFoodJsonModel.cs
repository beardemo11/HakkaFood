using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HakkaFood.Models
{
    public class HakkaFoodJsonModel
    {
        [Display(Name = "類別")]
        public string kind { get; set; }

        [Display(Name = "分類")]
        public string classification { get; set; }

        [Display(Name = "菜色名稱")]
        public string dishes_name { get; set; }

        [Display(Name = "創作者")]
        public string creative { get; set; }

        [Display(Name = "菜餚特色")]
        public string specialty_dishes { get; set; }

        [Display(Name = "作法")]
        public string Practic { get; set; }

        [Display(Name = "網址")]
        public string Url { get; set; }
    }
}