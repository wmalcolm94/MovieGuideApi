using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieGuideApi.Models 
{
    public class Chat
    {
        public int id { get; set; }
        [JsonIgnore]
        public ICollection<Message> messages { get; set; }
    }
}