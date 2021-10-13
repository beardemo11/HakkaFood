using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HakkaFood.Models
{
    public class HakkaFoodJsonModel
    {
        
        public string kind { get; set; }
        public string classification { get; set; }
        public string dishes_name { get; set; }
        public string creative { get; set; }
        public string specialty_dishes { get; set; }
        public string Practic { get; set; }
        public string Url { get; set; }
    }
}