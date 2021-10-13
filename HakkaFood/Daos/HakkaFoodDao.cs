using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using HakkaFood.Models;
using Newtonsoft.Json;

namespace HakkaFood.Daos
{
    public class HakkaFoodDao
    {
        public List<HakkaFoodJsonModel> GetAll()
        {
            const string url = "https://cloud.hakka.gov.tw/Pub/Opendata/DTST20171100016.json";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };

            var response = webClient.DownloadString(url);

            var hakkaFoodJsons = JsonConvert.DeserializeObject<List<HakkaFoodJsonModel>>(response);

            return hakkaFoodJsons;

        }
    }
}