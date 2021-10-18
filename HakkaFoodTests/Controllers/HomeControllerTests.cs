using Microsoft.VisualStudio.TestTools.UnitTesting;
using HakkaFood.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HakkaFood.Daos;
using HakkaFood.Models;

namespace HakkaFood.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void GetInfoTest()
        {
            var hakkaFoodJsons = new HakkaFoodDao();
            var DishesName = "排骨炆菜頭";
            var Type = "經典";

            var expected = "經典";

            var actual = hakkaFoodJsons.GetAll().Where(x => x.dishes_name == DishesName);

            

            //Assert.AreEqual(actual.FirstOrDefault());
        }
    }
}