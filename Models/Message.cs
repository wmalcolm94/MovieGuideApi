using System.Collections.Generic;
using System;

namespace MovieGuideApi.Models
{
    public class Message 
    {
        public int id { get; set; }
        public string message { get; set; }
        public DateTime sent { get; set; }
        public int chatId { get; set; }
        public Chat chat { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}