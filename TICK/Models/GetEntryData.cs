using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TICK.Controllers;

namespace TICK.Models
{
    public class GetEntryData
    {
        public List<Entry> Entry { get; set; }
        public float TotalHours { get { return Entry.Sum(item => item.Hours); ; } }

        public List<Project> Projects { get; set; }
    }
}