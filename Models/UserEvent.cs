namespace MovieGuideApi.Models
{
    public class UserEvent 
    {
        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public int eventId { get; set; }
        public Event evnt { get; set; }
    }
}