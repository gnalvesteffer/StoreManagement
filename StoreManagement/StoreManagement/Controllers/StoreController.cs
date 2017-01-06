using StoreManagement.Models.Forms;
using StoreManagement.Models.Services;
using System.Net;
using System.Web.Mvc;

namespace StoreManagement.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreService _storeService = new StoreService();

        [Route("stores")]
        public ActionResult StoreList()
        {
            return View();
        }

        [Route("store/{storeNumber}")]
        public ActionResult StoreDetail(int storeNumber)
        {
            return View();
        }
    }
}