﻿using System.Web.Mvc;
using mvcMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace mvcMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly CountryDB Context = new CountryDB();
        
        public ActionResult Index()
        {
            var Countries = Context.Countries.FindAll().SetSortOrder(SortBy<Country>.Ascending(r => r.CountryCode));
            return View(Countries);
        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Country _Country)
        {
            if (ModelState.IsValid)
            {
                Context.Countries.Insert(_Country);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string Id )
        {
            var Country = Context.Countries.FindOneById(new ObjectId(Id));
            return View(Country);
        }

        [HttpPost]
        public ActionResult Edit(Country _Country)
        {
            if (ModelState.IsValid)
            {
                Context.Countries.Save(_Country);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var rental = Context.Countries.FindOneById(new ObjectId(Id));
            return View(rental);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            var rental = Context.Countries.Remove(Query.EQ("_id", new ObjectId(Id)));
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}