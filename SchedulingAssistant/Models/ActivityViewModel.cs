namespace SchedulingAssistant.Models
{
    public class ActivityViewModel
    {
        public string Sport { get; set; }
        public DateTime MatchDate { get; set; }
        public TimeSpan Time { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Location { get; set; }
    }
}
