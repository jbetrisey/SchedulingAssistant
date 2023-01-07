using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SchedulingAssistant.Service;
public class GoogleCalendarServiceAgent
{
    private IClientService _clientService;
    private string _calendarId;
    private GoogleCredential _credential;

    public GoogleCalendarServiceAgent()
    {
        
        _clientService = new CalendarService(new BaseClientService.Initializer
        {
            ApplicationName = "Scheduling Assistant",
            HttpClientInitializer = _credential,
            ApiKey = "AIzaSyCGKn3WvmBEzHuC9qI2J1NbgQInayxqK5E",
        });
        _calendarId = "test";
    }
    public async Task Run(IGoogleAuthProvider auth)
    {
        _credential = await auth.GetCredentialAsync();
        CalendarListResource.ListRequest request = new CalendarListResource.ListRequest(_clientService);

        CalendarList calendarList= request.Execute();

        var test =  calendarList.Items;
    }

    public async Task CreateEvent(Event eventItem)
    {
        EventsResource.InsertRequest insertRequest = new EventsResource.InsertRequest(_clientService, eventItem, _calendarId);
        await insertRequest.ExecuteAsync();
    }

    public async Task<IList<Event>> GetListEvent()
    {
        EventsResource.ListRequest listRequest = new EventsResource.ListRequest(_clientService, _calendarId);

        Events events = await listRequest.ExecuteAsync();

        return events.Items;
    }
}
