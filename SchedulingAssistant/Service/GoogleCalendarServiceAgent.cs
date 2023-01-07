using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Security.Claims;

namespace SchedulingAssistant.Service;
public class GoogleCalendarServiceAgent
{
    private IClientService _clientService;
    private string _calendarId;
    private GoogleCredential _credential;

    public GoogleCalendarServiceAgent()
    {
        _calendarId = "test";
    }
   
    public async Task Run()
    {
        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            new[] { CalendarService.Scope.CalendarReadonly },
            "user",
            CancellationToken.None,
            new FileDataStore(GoogleWebAuthorizationBroker.Folder, true));
        
        var initializer = new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "ASP.NET MVC5 Calendar Sample",
        };
        var service = new CalendarService(initializer);
        CalendarListResource.ListRequest request = new CalendarListResource.ListRequest(service);

        CalendarList calendarList= request.Execute();

        var test =  calendarList.Items;
        }
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
