using Microsoft.AspNetCore.Mvc;
using SchedulingAssistant.Models;
using System.Diagnostics;
using Activity = SchedulingAssistant.Models.Activity;

namespace SchedulingAssistant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ActivityList(string sport, DateTime startDate, DateTime endDate)
        {
            // TODO : Get list of all activities
            List<Activity> allActivities = new List<Activity>();

            Activity a1 = new Activity() { Sport = "football", Day = 07, Month = 01, Year = 2023, League = "league", TeamAway = "Sion", TeamHome = "Lausanne", Time = DateTime.Now };
            Activity a2 = new Activity() { Sport = "football", Day = 08, Month = 01, Year = 2023, League = "league", TeamAway = "Sierre", TeamHome = "Martigny", Time = DateTime.Now };

            allActivities.Add(a1);
            allActivities.Add(a2);

            List<ActivityViewModel> activitiesVM = ConvertActivityList(allActivities);
            activitiesVM = FindActivities(activitiesVM, sport, startDate, endDate);

            return View(activitiesVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<ActivityViewModel> ConvertActivityList(List<Activity> activities)
        {
            List<ActivityViewModel> result = new List<ActivityViewModel>();
            foreach (Activity a in activities)
            {
                result.Add(ConvertActivity(a));
            }
            return result;
        }

        public ActivityViewModel ConvertActivity(Activity a)
        {
            ActivityViewModel activity = new ActivityViewModel();
            activity.Sport = a.Sport;
            activity.Location = a.League;
            activity.Team1 = a.TeamHome;
            activity.Team2 = a.TeamAway;
            TimeSpan time = a.Time.TimeOfDay;
            activity.MatchDate = new DateTime(a.Year, a.Month, a.Day) + time;

            return activity;
        }

        public List<ActivityViewModel> FindActivities(List<ActivityViewModel> activities, String sport, DateTime startDate, DateTime endDate)
        {
            List<ActivityViewModel> result = new List<ActivityViewModel>();

            foreach (ActivityViewModel a in activities)
            {
                if (a.Sport == sport)
                {
                    if (a.MatchDate >= startDate && a.MatchDate < endDate)
                    {
                        result.Add(a);
                    }
                }
            }

            return result;
        }


    }
}