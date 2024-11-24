using _9dars.Models;

namespace _9dars.Servises;

public class EventServices
{
    private List<Event> events;
    public EventServices()
    {
        events = new List<Event>();
    }
    /// Add 
    public bool AddNewEvent(Event NewEvent)
    {
        try
        {
            NewEvent.ID = Guid.NewGuid();
            events.Add(NewEvent);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public Event GetEventByID(Guid ID)
    {
        foreach(var _event in events)
        {
            if (_event.ID == ID)
            {
                return _event;
            }
        }

        return null;
    }
    /// Update
    public bool UpgradeEvent(Event newEvent)
    {
        var eventFromDB = GetEventByID(newEvent.ID);
        if (eventFromDB is null)
        {
            return false;
        }
        var index = events.IndexOf(eventFromDB);
        events[index] = newEvent;

        return true;
    }
    /// Delete
    public bool DeleteEvent(Guid ID)
    {
        var eventFromDB = GetEventByID(ID);
        if (eventFromDB is null)
        {
            return false;
        }
        events.Remove(eventFromDB);

        return true;
    }
    /// Read
    public List<Event> GetAllEvents()
    {
        return events;
    }
    /// Display Info
    public void DisplayInfo(Event _event)
    {
        Console.WriteLine($"ID: {_event.ID}");
        Console.WriteLine($"Title: {_event.Title}");
        Console.WriteLine($"Location: {_event.Location}");
        Console.WriteLine($"Date: {_event.Date}");
        Console.WriteLine($"Description: {_event.Description}");
        Console.WriteLine("Attendees: ");
        foreach (var name in _event.Attendees)
        {
            Console.WriteLine($" - {name}");
        }
        Console.WriteLine("Tags: ");
        foreach (var tag in _event.Tags)
        {
            Console.WriteLine($" - {tag}");
        }
    }
    /// Get Events By Location
    public List<Event> GetEventsByLocation(string location)
    {
        var eventsByLocation = new List<Event>();
        foreach (var _event in events)
        {
            if (_event.Location == location)
            {
                eventsByLocation.Add(_event);
            }
        }

        return eventsByLocation;
    }
    /// Get Popular Event
    public Event GetPopularEvent()
    {
        var mostPopularevent = new Event();
        foreach (var eventItem in events)
        {
            if (eventItem.Attendees.Count > mostPopularevent.Attendees.Count)
            {
                mostPopularevent = eventItem;
            }
        }

        return mostPopularevent;
    }
    /// Get Max Tagged Event
    public Event GetMaxTaggedEvent()
    {
        var mostTaggedEvent = new Event();
        foreach (var eventItem in events)
        {
            if (eventItem.Attendees.Count > mostTaggedEvent.Attendees.Count)
            {
                mostTaggedEvent = eventItem;
            }
        }

        return mostTaggedEvent;
    }
    /// Add Person To Event
    public bool AddPersonToEvent(Guid Id, string person)
    {
        var EventFromDB = GetEventByID(Id);
        if (EventFromDB is null)
        {
            return false;
        }
        EventFromDB.Attendees.Add(person);

        return true;
    }
}
