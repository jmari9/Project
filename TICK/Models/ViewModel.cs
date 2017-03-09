using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TICK.Models
{
    public class ViewModel
    {
        public List<Project> Project { get; set; }
        public List<User> User { get; set; }
        public List<GTask> GTask { get; set; }
        public List<Client> Client { get; set; }
        public List<Entry> Entry { get; set; }
    }
}