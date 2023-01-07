using Microsoft.AspNetCore.Mvc;
using SchedulingAssistant.Models;

namespace SchedulingAssistant.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
            activity.MatchDate = new DateTime(a.Year, a.Month, a.Day);
            activity.Time = a.Time;

            return activity;
        }

        public List<ActivityViewModel> FindActivities(List<ActivityViewModel> activities, String sport, DateTime startDate, DateTime endDate)
        {
            List<ActivityViewModel> result = new List<ActivityViewModel>();

            foreach (ActivityViewModel a in activities)
            {
                if(a.Sport == sport)
                {
                    if(a.MatchDate >= startDate && a.MatchDate < endDate) {
                        result.Add(a);
                    }
                }
            }

            return result;
        }
    }
}
