using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WhatsappMessageFromCloudAPI.Controllers
{
    public class WhatsappController : Controller
    {
        // GET: Whatsapp
        public async Task<ActionResult> SendWhatsAppMsg()
        {
           
            try
            { 
            string mobile = "918522856452";
            string templateName = "hello_world";
            string Token = "EAAOqxLgHJIYBO1G7H8UUNSlmjXRlPObSYfBrfsIxMt6FOG9YHBky5Ap7H2di7PAri5ZBEzSXG9P0cJUFrwdvZBpcLT7OZBUfUPftI5ihUnZCS7mMtNhHgxNIVwKHuJimKdnia2Dsvqz2TpzlcbEIwRFSoUiJxIfYaxWN8Vwc9LYv7GX0AZCnYZAXqmKr6IVPfIK1OjIByDN4d4CVleJWPQP92WxikZD";
            string BaseUrl = "https://graph.facebook.com/v17.0/154702904386106/";
            Uri baseurl = new Uri(BaseUrl);
            var client = new RestSharp.RestClient(baseurl);
            var request = new RestRequest("messages", Method.POST);
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("Content-Type", "application/json");
            var body = "{\"messaging_product\": \"whatsapp\",\"to\": \"" + mobile + "\",\"type\": \"template\",\"template\": { \"name\": \"" + templateName + "\",\"language\":{ \"code\": \"en_US\"}}}";
            request.AddJsonBody(body);
            IRestResponse response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {

                    TempData["SuccessMessage"] = "WhatsApp message sent successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error sending WhatsApp message: " + response.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
            }
            return View();
        }
    }
}