using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace MovieGuideApi.Models
{
    public class Message 
    {
        public int id { get; set; }
        public string message { get; set; }
        public DateTime sent { get; set; }
        public int chatId { get; set; }
        [JsonIgnore]
        public Chat chat { get; set; }
        public int userId { get; set; }
        [JsonIgnore]
        public User user { get; set; }
    }
}