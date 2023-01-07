namespace SchedulingAssistant.Models
{
    public class CompatibleActivity
    {
        public string Sport { get; set; }
        public string League { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public TimeSpan Time { get; set; }
        public string TeamHome { get; set; }
        public string TeamAway { get; set; }
    }
}
