using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HakkaFood.Daos;
using HakkaFood.Models;

namespace HakkaFood.Controllers
{
    public class HomeController : Controller
    {
        private HakkaFoodDataBaseEntities db = new HakkaFoodDataBaseEntities();
        public ActionResult Index()
        {
            return View();
        }

        public string GetInfo()
        {
            HakkaFoodDao hakkaFoodDao = new HakkaFoodDao();

            List<HakkaFoodJsonModel> hakkaFoodJsonModels = hakkaFoodDao.GetAll().Take(5).ToList();
            string strResult = "false";
            try
            {
                foreach (var item in hakkaFoodJsonModels)
                {
                    HakkaFoodData data = new HakkaFoodData();
                    data.Classification = item.Classification;
                    data.Creative = item.Creative;
                    data.SpecialtyDishes = item.SpecialtyDishes;
                    data.DishesName = item.DishesName;
                    data.Kind = item.Kind;
                    data.Practic = item.Practic;
                    data.Url = item.Url;
                    db.HakkaFoodData.Add(data);
                    db.SaveChanges();
                    strResult = "true";
                }
                return strResult;

                //return View(hakkaFoodJsonModels);

            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

    }
}