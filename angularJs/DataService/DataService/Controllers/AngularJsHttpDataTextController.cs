using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace DataService.Controllers
{
    public class AngularJsHttpDataTextController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var stream = new FileStream(@"D:\MyLearn\AngularJs\runoob.com\DataService\DataService\JsonData\Person.json", FileMode.Open);

            var result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return result;
        }

        [Route("ValidSuccess")]
        public bool ValidSuccess(string username)
        {
            return username=="aaron";
        }
    }
}
