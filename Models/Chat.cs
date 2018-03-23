using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieGuideApi.Models 
{
    public class Chat
    {
        public int id { get; set; }
        public int movieId { get; set; }
        public Movie movie { get; set; }
        public ICollection<Message> messages { get; set; }
    }
}