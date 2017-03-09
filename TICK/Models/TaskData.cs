using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TICK.Models
{
    public class TaskData
    {
       
            public string id { get; set; }
            public string name { get; set; }
            public double budget { get; set; }
            public int position { get; set; }
            public int project_id { get; set; }
            public object date_closed { get; set; }
            public bool billable { get; set; }
            public string url { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public double total_hours { get; set; }
            public List<Entry> entries { get; set; }
            public List<Project> project { get; set; }
        
    }
}