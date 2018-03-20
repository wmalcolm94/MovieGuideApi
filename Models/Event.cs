using System;
using System.Collections.Generic;

namespace MovieGuideApi.Models
{
    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public Chat chat { get; set; }
        public ICollection<User> users { get; set; }
    }
}
