using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TICK.Models
{
    public class Role
    {


        public int subscription_id { get; set; }
        public string company { get; set; }
        public string api_token { get; set; }

    }



    public class Project
    {


        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "budget")]
        public float Budget { get; set; }

        [JsonProperty(PropertyName = "date_closed")]
        public object DateClosed { get; set; }

        [JsonProperty(PropertyName = "notifications")]
        public bool Notifications { get; set; }

        [JsonProperty(PropertyName = "billable")]
        public bool Billable { get; set; }

        [JsonProperty(PropertyName = "recurring")]
        public bool Recurring { get; set; }

        [JsonProperty(PropertyName = "client_id")]
        public int ClientId { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }
    }

    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "timezone ")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }


        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

    }

    public class GTask
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "budget")]
        public double Budget { get; set; }

        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }

        [JsonProperty(PropertyName = "project_id")]
        public int ProjectId { get; set; }

        [JsonProperty(PropertyName = "date_closed")]
        public object DateClosed { get; set; }

        [JsonProperty(PropertyName = "billable")]
        public bool Billable { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }
    }

    public class Client
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "archive")]
        public bool Archive { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }
    }

    public class Entry
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "hours")]
        public float Hours { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        [JsonProperty(PropertyName = "task_id")]
        public int TaskId { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }

    }

}