using StoreManagement.Models.Forms;
using StoreManagement.Models.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreManagement.Controllers
{
    public class StoreController : ApiController
    {
        private readonly StoreService _storeService = new StoreService();

        [HttpPost]
        [Route("api/store/add")]
        public HttpResponseMessage AddStore(StoreForm form)
        {
            var validationResponse = _storeService.AddStore(form);
            return Request.CreateResponse(validationResponse.IsValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest, validationResponse.ValidationMessage);
        }

        [HttpPut]
        [Route("api/store/{storeNumber}")]
        public HttpResponseMessage UpdateStore(int storeNumber, [FromBody]StoreForm form)
        {
            form.StoreNumber = storeNumber;
            var validationResponse = _storeService.UpdateStore(storeNumber, form);
            return Request.CreateResponse(validationResponse.IsValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest, validationResponse.ValidationMessage);
        }

        [HttpDelete]
        [Route("api/store/{storeNumber}")]
        public HttpResponseMessage DeleteStore(int storeNumber)
        {
            var validationResponse = _storeService.DeleteStore(storeNumber);
            return Request.CreateResponse(validationResponse.IsValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest, validationResponse.ValidationMessage);
        }
    }
}