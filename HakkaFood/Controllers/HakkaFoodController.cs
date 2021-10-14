using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HakkaFood.Models;

namespace HakkaFood.Controllers
{
    public class HakkaFoodController : Controller
    {
        private HakkaFoodDataBaseEntities db = new HakkaFoodDataBaseEntities();

        // GET: HakkaFood
        public ActionResult Index()
        {
            return View(db.HakkaFoodData.ToList());
        }


    }
}
