using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HakkaFood.Daos;
using HakkaFood.Models;
using Newtonsoft.Json;

namespace HakkaFood.Controllers
{
    public class HomeController : Controller
    {
        private HakkaFoodDataBaseEntities db = new HakkaFoodDataBaseEntities();
        public ActionResult Index()
        {
            HakkaFoodDao hakkaFoodDao = new HakkaFoodDao();

            List<HakkaFoodJsonModel> hakkaFoodJsonModels = hakkaFoodDao.GetAll().Take(5).ToList();

            return View(hakkaFoodJsonModels);
        }




        public string InsertData(string id)
        {
            HakkaFoodDao hakkaFoodDao = new HakkaFoodDao();

            List<HakkaFoodJsonModel> hakkaFoodJsonModels = hakkaFoodDao.GetAll().Where(x => x.dishes_name == id).ToList();
            string strResult = "false";
            try
            {
                foreach (var item in hakkaFoodJsonModels)
                {
                    HakkaFoodData data = new HakkaFoodData();
                    data.Classification = item.classification;
                    data.Creative = item.creative;
                    data.SpecialtyDishes = item.specialty_dishes;
                    data.DishesName = item.dishes_name;
                    data.Kind = item.kind;
                    data.Practic = item.Practic;
                    data.Url = item.Url;
                    db.HakkaFoodData.Add(data);
                    db.SaveChanges();
                    strResult = "true";
                }
                return strResult;


            }
            catch (Exception exception)
            {
                throw exception;
            }

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}