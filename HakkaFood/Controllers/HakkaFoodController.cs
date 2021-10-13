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


        // GET: HakkaFood/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HakkaFood/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HakkaFood/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HakkaFood/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
