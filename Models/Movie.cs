namespace MovieGuideApi.Models
{
    public class Movie 
    {
        public int id { get; set; }
        public string name { get; set; }
        public int chatId { get; set; }
        public Chat chat { get; set; }
    }
}