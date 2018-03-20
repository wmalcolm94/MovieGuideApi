using System.Collections.Generic;

namespace MovieGuideApi.Models 
{
    public class Chat
    {
        public int id { get; set; }
        public Event evnt { get; set; }
        public ICollection<Message> messages { get; set; }
    }
}