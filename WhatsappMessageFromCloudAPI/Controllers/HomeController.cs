using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WhatsappMessageFromCloudAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        private async Task<string> SendWhatsAppMsg()
        {
            string responsestatus = "";
            string mobile = "918522856452";
            string templateName = "hello_world";
            string Token = "EAAOHgq45dcwBO8CZCTAiZAZAPHUh8TCVzhJLfi6nyXgWEDxao3tzXcQd0ZBiVUiWDYGY6ZAn2HMB9EGoNtT4uUkBMENOh938WXtQvMTHkHF00ZB8HLuZBBQ0P2uvZBhXIVItVY25Yle7Eyon79m4mLZA1gEbJFZACxsGshuKGsKt5WhZCVPmt22YRgKSaTlyzKDWvaPKneMenTxZANvYJSdDH4UkclhgyKgZD";
            string BaseUrl = "https://graph.facebook.com/v17.0/154702904386106/";
            Uri baseurl = new Uri(BaseUrl);
            var client = new RestSharp.RestClient(baseurl);
            var request = new RestRequest("messages", Method.POST);
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("Content-Type", "application/json");
            var body = "{\"messaging_product\": \"whatsapp\",\"to\": \"" + mobile + "\",\"type\": \"template\",\"template\": { \"name\": \"" + templateName + "\",\"language\":{ \"code\": \"en_US\"}}}";
            request.AddJsonBody(body);
            IRestResponse response = await client.ExecuteAsync(request);
            //if(response.StatusCode.ToString() = "OK")
            //{

            //}
            return responsestatus;
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