using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HakkaFood.Daos;
using HakkaFood.Models;
using Newtonsoft.Json;
using WebGrease.Css.Ast.Selectors;

namespace HakkaFood.Controllers.api
{
    public class HakkaFoodController : ApiController
    {
        private HakkaFoodDataBaseEntities db = new HakkaFoodDataBaseEntities();

        // GET: api/HakkaFood
        public IEnumerable<HakkaFoodJsonModel> Get()
        {
            HakkaFoodDao hakkaFoodDao = new HakkaFoodDao();

            var hakkaFoodJsons = hakkaFoodDao.GetAll().Where(x => x.specialty_dishes.Length < 50);

            return hakkaFoodJsons;

        }

        // GET: api/HakkaFood/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HakkaFood
        public void Post([FromBody] HakkaFoodJsonModel value)
        {
            HakkaFoodDao hakkaFoodDao = new HakkaFoodDao();

            List<HakkaFoodJsonModel> hakkaFoodJsonModels = hakkaFoodDao.GetAll().Where(x => x.dishes_name == value.dishes_name).ToList();

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
                }

                
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        // PUT: api/HakkaFood/5
        public void Put(int id, [FromBody]string value)
        {
           
        }

        // DELETE: api/HakkaFood/5
        public void Delete(int id)
        {
        }
    }
}
