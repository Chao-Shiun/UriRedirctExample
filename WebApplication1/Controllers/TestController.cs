using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        public async Task<IHttpActionResult> PostAsync()
        {
            var headers = Request.Headers;
            var allKeys = HttpContext.Current.Request.Headers.AllKeys;

            HttpClient httpClient = new HttpClient();

            foreach (var item in allKeys)
            {
                if (headers.TryGetValues(item, out IEnumerable<string> list))
                {
                    httpClient.DefaultRequestHeaders.Add(item, headers.GetValues(item));
                }
            }

            HttpResponseMessage response = await httpClient.PostAsync(new Uri("http://localhost:51486/api/Test2"), Request.Content).ConfigureAwait(false);

            return ResponseMessage(response);
        }
    }
}
