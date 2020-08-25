using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SaferSpacesClient.Models
{
  public class Event
  {
    public Event()
    {
      this.Testimonials = new HashSet<Testimonial>();
    }

    public int EventId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime EventDate { get; set; }
    [Required]
    public DateTime EventTime { get; set; }
    [Required]
    public string Description { get; set; }
    public virtual ICollection<Testimonial> Testimonials { get; set; }

    public static List<Events> GetEvents()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Place> eventList = JsonConvert.DeserializeObject<List<Event>>(jsonResponse.ToString());

      return eventList;
    }

    public static Event GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Event happening = JsonConvert.DeserializeObject<Event>(jsonResponse.ToString());
      return happening;
    }

    public static void Post(Place place)
    {
      string jsonPlace = JsonConvert.SerializeObject(place);
      var apiCallTask = ApiHelper.Post(jsonPlace);
    }

    public static void Put(Place place)
    {
      string jsonPlace = JsonConvert.SerializeObject(place);
      var apiCallTask = ApiHelper.Put(place.PlaceId, jsonPlace);
    }
    
    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}