﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellYourTime.Models;

namespace SellYourTime.Controllers
{
    public class SearchController : Controller
    {
        private SellYourTimeRepository _repo = new SellYourTimeRepository();
        //
        // GET: /Search/

        public ActionResult Search(String searchQuery, String searchMethod = "content")
        {
            if (searchQuery == null) return RedirectToAction("Index", "Home");
            var offers = _repo.Search(searchQuery);
            var tags = _repo.GetOffersByTag(searchQuery);
            ViewBag.SearchQuery = searchQuery;
            ViewBag.SearchMethod = searchMethod;
            ViewBag.SearchText = offers;
            ViewBag.SearchTag = tags;
            return View();
        }

    }
}
