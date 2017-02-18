using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using System.Collections;
using TICK.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace TICK.Controllers
{
    public class TickDataController : Controller
    {
    
        public string responseFromServer { get; private set; }

        public async Task<Role> GetRole()
        {
            HttpClient client = new HttpClient();

            byte[] byteArray = Encoding.ASCII.GetBytes("email_address:password");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            client.DefaultRequestHeaders.Add("User-Agent", "MyCoolApp (me@example.com)");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpResponseMessage response = await client.GetAsync("https://www.tickspot.com/api/v2/roles.json");
            HttpContent content = response.Content;

            List<Role> roles = new List<Role>();
            String jsonString = await response.Content.ReadAsStringAsync();
            roles = JsonConvert.DeserializeObject<List<Role>>(jsonString);

            return roles[0];
        }


        public async Task<ActionResult> Data()
        {
            Role role = await GetRole();

            List<Project> projects = new List<Project>();
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "MyCoolApp (me@example.com)");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "token=" + role.api_token);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpResponseMessage task = await client.GetAsync("https://www.tickspot.com/" + role.subscription_id + "/api/v2/projects.json");
            String jsonString = await task.Content.ReadAsStringAsync();
            projects = JsonConvert.DeserializeObject<List<Project>>(jsonString);

            return View(projects);
        }
        public ActionResult Index()
        {
            return View();
        }


        private void returnView(List<Role> model)
        {
            throw new NotImplementedException();
        }





        public static string ScreenScrape(string url)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {

                return client.DownloadString(url);
            }
        }


    }


    internal class responseContent
    {
        internal static Task<Stream> ReadAsStreamAsync()
        {
            throw new NotImplementedException();
        }
    }
}
