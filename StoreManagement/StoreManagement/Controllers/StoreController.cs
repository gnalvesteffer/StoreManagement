using StoreManagement.Models.Forms;
using StoreManagement.Models.Services;
using System.Net;
using System.Web.Mvc;

namespace StoreManagement.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreService _storeService = new StoreService();

        [Route("/stores")]
        public ActionResult StoreList()
        {
            return PartialView();
        }

        [Route("/store/{storeNumber}")]
        public ActionResult StoreDetail(int storeNumber)
        {
            return PartialView();
        }

        [HttpPost]
        [Route("/api/store/add")]
        public void AddStore(AddStoreForm form)
        {
            if(!_storeService.AddStore(form)) throw new System.Web.Http.HttpResponseException(HttpStatusCode.Conflict);
        }

        [HttpPost]
        [Route("/api/store/{storeNumber}")]
        public void UpdateStore(int storeNumber, UpdateStoreForm form)
        {
            if (!_storeService.UpdateStore(storeNumber, form)) throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
        }

        [HttpDelete]
        [Route("/api/store/{storeNumber}")]
        public void DeleteStore(int storeNumber)
        {
            if (!_storeService.DeleteStore(storeNumber)) throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}