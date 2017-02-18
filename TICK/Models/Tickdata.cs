using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public int id { get; set; }
        public string name { get; set; }
        public float budget { get; set; }
        public object date_closed { get; set; }
        public bool notifications { get; set; }
        public bool billable { get; set; }
        public bool recurring { get; set; }
        public int client_id { get; set; }
        public int owner_id { get; set; }
        public string url { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

}