using StoreManagement.Models.Forms;
using StoreManagement.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreManagement.Controllers
{
    public class StoreApiController : ApiController
    {
        private readonly StoreService _storeService = new StoreService();

        [HttpPost]
        [Route("api/store/add")]
        public void AddStore([FromBody]AddStoreForm form)
        {
            if (!_storeService.AddStore(form)) throw new System.Web.Http.HttpResponseException(HttpStatusCode.Conflict);
        }

        [HttpPost]
        [Route("api/store/{storeNumber}")]
        public void UpdateStore(int storeNumber, [FromBody]UpdateStoreForm form)
        {
            if (!_storeService.UpdateStore(storeNumber, form)) throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
        }

        [HttpDelete]
        [Route("api/store/{storeNumber}")]
        public void DeleteStore(int storeNumber)
        {
            if (!_storeService.DeleteStore(storeNumber)) throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
