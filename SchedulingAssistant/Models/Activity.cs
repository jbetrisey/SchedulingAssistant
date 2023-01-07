namespace SchedulingAssistant.Models
{
    public class Activity
    {
        public string Sport { get; set; }
        public string League { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime Time { get; set; }
        public string TeamHome { get; set; }
        public string TeamAway { get; set; }
    }
    
}
