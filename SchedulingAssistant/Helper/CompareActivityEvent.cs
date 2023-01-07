using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SchedulingAssistant.Models;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Collections.Generic;

namespace SchedulingAssistant.Helper
{
    public class CompareActivityEvent
    {
        List<Activity> activities = GetActivitiesFromCsv("events.csv");


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

        public static List<Activity> GetActivitiesFromCsv(string fileName)
        {
            List<Activity> results = null;

            var filePath = "\\SchedulingAssistant\\wwwroot\\" + fileName;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Encoding = Encoding.UTF8,
                Delimiter = ","

            };

            using (var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, config))
                {
                    results = (List<Activity>?)csv.GetRecords<Activity>();
                }
            }
            return results;
        }

    }



}
