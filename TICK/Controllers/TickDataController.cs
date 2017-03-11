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
using System.Net.Mail;

namespace TICK.Controllers
{
    public class TickDataController : Controller
    {

        public async Task<ActionResult> Index()
        {

            ViewModel mymodel = new ViewModel();
            mymodel.Project = await GetProject();
            mymodel.User = await GetUser();
            mymodel.GTask = await GetTask();
            mymodel.Client = await GetClient();
            mymodel.Entry = await GetEntry();
            return View(mymodel);
        }


        public async Task<Role> GetRole()
        {
            HttpClient client = new HttpClient();

            byte[] byteArray = Encoding.ASCII.GetBytes("email:password");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            client.DefaultRequestHeaders.Add("User-Agent","MyCoolApp (me@example.com)");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpResponseMessage response = await client.GetAsync("https://www.tickspot.com/api/v2/roles.json");
            HttpContent content = response.Content;

            List<Role> roles = new List<Role>();
            String jsonString = await response.Content.ReadAsStringAsync();
            roles = JsonConvert.DeserializeObject<List<Role>>(jsonString);

            return roles[0];
        }


        public async Task<List<Project>> GetProject()
        {
            Role role = await GetRole();

            List<Project> projects = new List<Project>();
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "MyCoolApp(me@example.com)");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "token=" + role.api_token);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpResponseMessage task = await client.GetAsync("https://www.tickspot.com/" + role.subscription_id + "/api/v2/projects.json");
            String jsonString = await task.Content.ReadAsStringAsync();
            projects = JsonConvert.DeserializeObject<List<Project>>(jsonString);

            return projects;
        }



        public async Task<List<User>> GetUser()
        {
            Role role = await GetRole();
            List<User> users = new List<User>();
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0 (mailaddress)");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "token=" + role.api_token);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpResponseMessage task = await client.GetAsync("https://www.tickspot.com/" + role.subscription_id + "/api/v2/users.json");
            String jsonString = await task.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(jsonString);

            return users;
        }

        public async Task<List<GTask>> GetTask()
        {
            Role role = await GetRole();
            List<GTask> tasks = new List<GTask>();
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0 (mailaddress)");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "token=" + role.api_token);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpResponseMessage task = await client.GetAsync("https://www.tickspot.com/" + role.subscription_id + "/api/v2/tasks.json");
            String jsonString = await task.Content.ReadAsStringAsync();
            tasks = JsonConvert.DeserializeObject<List<GTask>>(jsonString);

            return tasks;
        }

        public async Task<List<Client>> GetClient()
        {
            Role role = await GetRole();
            List<Client> clients = new List<Client>();
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0 (mailaddress)");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "token=" + role.api_token);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpResponseMessage task = await client.GetAsync("https://www.tickspot.com/" + role.subscription_id + "/api/v2/tasks.json");
            String jsonString = await task.Content.ReadAsStringAsync();
            clients = JsonConvert.DeserializeObject<List<Client>>(jsonString);

            return clients;
        }


        public async Task<List<Entry>> GetEntry(int userId = 0)
        {
            Role role = await GetRole();
            List<Entry> entries = new List<Entry>();
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0 (mailaddress)");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "token=" + role.api_token);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            string parameters = "?start_date='2015-12-27'&end_date='2018-02-28'&billable='true'";

            if (userId != 0)
            { parameters += "&user_id=" + userId; }

            HttpResponseMessage task = await client.GetAsync("https://www.tickspot.com/" + role.subscription_id + "/api/v2/entries.json" + parameters);

            String jsonString = await task.Content.ReadAsStringAsync();
            entries = JsonConvert.DeserializeObject<List<Entry>>(jsonString);

            return entries;
        }






        public async Task<ActionResult> GetEntryData(int userId)
        {

            List<Entry> entries = await GetEntry(userId);

            List<int> taskIds = entries.Select(e => e.TaskId).Distinct().ToList();

            List<TaskData> tasks = new List<TaskData>();

            foreach (int taskId in taskIds)
            {
                TaskData task = await GetTaskData(taskId);
                if (task != null)
                {
                    tasks.Add(task);
                }
            }
            List<Project> projects = tasks.GroupBy(t => t.Project.Id).Select(g => g.First()).ToList().Select(t => t.Project).ToList();

            GetEntryData model = new GetEntryData();
            model.Entry = entries;
            model.Projects = projects;

            return PartialView("EntryData", model);

        }


        public async Task<TaskData> GetTaskData(int taskId)
        {
            Role role = await GetRole();
            TaskData gtask = null;
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0 (mailaddress)");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "token=" + role.api_token);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            HttpResponseMessage task = await client.GetAsync("https://www.tickspot.com/" + role.subscription_id + "/api/v2/tasks/" + taskId + ".json");
            String jsonString = await task.Content.ReadAsStringAsync();
            gtask = JsonConvert.DeserializeObject<TaskData>(jsonString);

            return gtask;
        }



        private void SendEmail()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("Your mailaddress", "Sender Name", System.Text.Encoding.UTF8);
            message.Subject = "Warning!";
            message.To.Add("mailaddress");
            message.Body = "Please enter hours!";
            message.IsBodyHtml = true;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("From Email Address", "Password(Sender Mail)");
            client.Send(message);
        }



    }


   
}
