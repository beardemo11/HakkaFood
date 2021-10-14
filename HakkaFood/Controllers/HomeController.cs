using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
            return View();
        }




        public string InsertData(string id)
        {
            HakkaFoodDao hakkaFoodDao = new HakkaFoodDao();

            List<HakkaFoodJsonModel> hakkaFoodJsonModels = hakkaFoodDao.GetAll().Where(x => x.dishes_name == id).ToList();
            string strResult = "";
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
                    strResult = data.DishesName + "存入資料庫!";
                }
                return strResult;


            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public string GetInfo(string id)
        {
            const string url = "https://cloud.hakka.gov.tw/Pub/Opendata/DTST20171100016.json";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };

            var response = webClient.DownloadString(url);

            var hakkaFoodJsons = JsonConvert.DeserializeObject<List<HakkaFoodJsonModel>>(response).Where(x=>x.specialty_dishes.Length <50);

            return JsonConvert.SerializeObject(hakkaFoodJsons);

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