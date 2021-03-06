﻿using StoreManagement.Models.Services;
using System.Web.Mvc;

namespace StoreManagement.Controllers
{
    public class SiteController : Controller
    {
        private readonly StoreService _storeService = new StoreService();
        
        public ActionResult Index()
        {
            return View();
        }

        [Route("stores")]
        public ActionResult StoreList()
        {
            return View(_storeService.GetStores());
        }

        [Route("store/{storeNumber}")]
        public ActionResult StoreDetail(int storeNumber)
        {
            return View(_storeService.GetStore(storeNumber));
        }

        [Route("store/new")]
        public ActionResult AddStore()
        {
            return View();
        }
    }
}
