using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieGuideApi.Models
{
    public class User 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}