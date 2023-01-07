using Microsoft.AspNetCore.Mvc.Infrastructure;
using SchedulingAssistant.Models;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace SchedulingAssistant.Helper
{
    public class Compare
    {
        List<Activity> activities;
        //activities = getFromCsv
        List<MyCalendarEvent> myEvents;
        //myEvents = getFromGoogle
        List<Activity> compatibleActivities;
        /* 
         foreach(Activity activity in activities){
             foreach(MyCalendarEvent myCalendarEvent in myEvents){
                 //tester que l'activité soit ok
                    compatibleActivities.Add(activity);

             }

         }

         */



    }
}
