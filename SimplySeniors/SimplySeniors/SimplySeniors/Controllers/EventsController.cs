using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplySeniors.DAL;
using SimplySeniors.Models;
using SimplySeniors.Models.ViewModel;
using Microsoft.AspNet.Identity;
using System.Globalization;
using SimplySeniors.Attributes;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SimplySeniors.Controllers
{

    public class SelectListItemHelper
    {
        public static IEnumerable<SelectListItem> GetStatesList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
        new SelectListItem() {Text="Alabama", Value="Alabama"},
        new SelectListItem() { Text="Alaska", Value="Alaska"},
        new SelectListItem() { Text="Arizona", Value="Arizona"},
        new SelectListItem() { Text="Arkansas", Value="Arkansas"},
        new SelectListItem() { Text="California", Value="California"},
        new SelectListItem() { Text="Colorado", Value="Colorado"},
        new SelectListItem() { Text="Connecticut", Value="Connecticut"},
        new SelectListItem() { Text="Delaware", Value="Delaware"},
        new SelectListItem() { Text="Florida", Value="Florida"},
        new SelectListItem() { Text="Georgia", Value="Georgia"},
        new SelectListItem() { Text="Hawaii", Value="Hawaii"},
        new SelectListItem() { Text="Idaho", Value="Idaho"},
        new SelectListItem() { Text="Illinois", Value="Illinois"},
        new SelectListItem() { Text="Indiana", Value="Indiana"},
        new SelectListItem() { Text="Iowa", Value="Iowa"},
        new SelectListItem() { Text="Kansas", Value="Kansas"},
        new SelectListItem() { Text="Kentucky", Value="Kentucky"},
        new SelectListItem() { Text="Louisiana", Value="Louisiana"},
        new SelectListItem() { Text="Maine", Value="Maine"},
        new SelectListItem() { Text="Maryland", Value="Maryland"},
        new SelectListItem() { Text="Massachusetts", Value="Massachusetts"},
        new SelectListItem() { Text="Michigan", Value="Michigan"},
        new SelectListItem() { Text="Minnesota", Value="Minnesota"},
        new SelectListItem() { Text="Mississippi", Value="Mississippi"},
        new SelectListItem() { Text="Missouri", Value="Missouri"},
        new SelectListItem() { Text="Montana", Value="Montana"},
        new SelectListItem() { Text="Nebraska", Value="Nebraska"},
        new SelectListItem() { Text="Nevada", Value="Nevada"},
        new SelectListItem() { Text="New Hampshire", Value="New Hampshire"},
        new SelectListItem() { Text="New Jersey", Value="New Jersey"},
        new SelectListItem() { Text="New Mexico", Value="New Mexico"},
        new SelectListItem() { Text="New York", Value="New York"},
        new SelectListItem() { Text="North Carolina", Value="North Carolina"},
        new SelectListItem() { Text="North Dakota", Value="North Dakota"},
        new SelectListItem() { Text="Ohio", Value="Ohio"},
        new SelectListItem() { Text="Oklahoma", Value="Oklahoma"},
        new SelectListItem() { Text="Oregon", Value="Oregon"},
        new SelectListItem() { Text="Pennsylvania", Value="Pennsylvania"},
        new SelectListItem() { Text="Rhode Island", Value="Rhode Island"},
        new SelectListItem() { Text="South Carolina", Value="South Carolina"},
        new SelectListItem() { Text="South Dakota", Value="South Dakota"},
        new SelectListItem() { Text="Tennessee", Value="Tennessee"},
        new SelectListItem() { Text="Texas", Value="Texas"},
        new SelectListItem() { Text="Utah", Value="Utah"},
        new SelectListItem() { Text="Vermont", Value="Vermont"},
        new SelectListItem() { Text="Virginia", Value="Virginia"},
        new SelectListItem() { Text="Washington", Value="Washington"},
        new SelectListItem() { Text="West Virginia", Value="West Virginia"},
        new SelectListItem() { Text="Wisconsin", Value="Wisconsin"},
        new SelectListItem() { Text="Wyoming", Value="Wyoming"}
            };
            return items;
        }
    }

    public class EventApiFields
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Price { get; set; }
        public int Length { get; set; }
        public string ImageURL { get; set; }
        public string LinkURL { get; set; }


    }

    [CustomAuthorize]
    public class EventsController : Controller
    {
        private EventContext db = new EventContext();
        private ProfileContext db2 = new ProfileContext();

        // GET: Events, ordered by date (newest at top, further out at bottom)
        public ActionResult Index()
        {
            string value = User.Identity.GetUserId();
            string profileCity = db2.Profiles.Where(x => x.USERID == value).Select(x => x.CITY).FirstOrDefault();
            string location = profileCity;
            ViewBag.City = location;
            return View(db.Events.OrderBy(x => x.STARTDATE).ToList());
        }

        // HTTP GET method was created for searching events in the Events/index. 
        public ActionResult SearchEvents()
        {
            return View();
        }

        // HTTP POST method was created for searching events in the Events/index, ordered by closest/upcoming events at top, farther out ones at bottom. 
        [HttpPost]
        public ActionResult SearchEvents(string searchString)
        {
            {
                IQueryable<Event> products = db.Events;
                if (!String.IsNullOrEmpty(searchString))
                {
                    products = products.Where(s => s.NAME.Contains(searchString) || s.CITY.Contains(searchString) || s.STATE.Contains(searchString));   // Searching for matches through name or location. 
                    ViewBag.Message = "Your product was found";         // Insert message if item is not found. 
                    return View(products.OrderBy(x => x.STARTDATE).ToList()); // Sorting by date
                }
                else
                {
                    ViewBag.Message = "Sorry your product was not found"; // Insert message if item is not found. 
                    return View(); 
                }
            }
        }

        //Pass other functions into here to request info for events API
        private string SendRequest(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Accept = "application/json";
            System.Diagnostics.Debug.WriteLine("request: " + request);
            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

        //Getting all necessary data for external events
        public ActionResult ExternalEvents()
        {
            string value = User.Identity.GetUserId();
            string profileCity = db2.Profiles.Where(x => x.USERID == value).Select(x => x.CITY).FirstOrDefault();
            string profileState = db2.Profiles.Where(x => x.USERID == value).Select(x => x.STATE).FirstOrDefault();
            string keywords = Request.QueryString["keywords"];
            string location = profileCity;
            string locationState = profileState;
            string newUrlName = string.Format("http://api.eventful.com/json/events/search?keywords={0}&location={1}%20{2}&page_size=50&include=price&include=tz_city&app_key=QhMNW3GgHB8WJZht", keywords, location, locationState);
            string json = SendRequest(newUrlName);
            JObject eventArray = JObject.Parse(json);

            int length = (int)eventArray["total_items"]; //total number in array of events for location
            if (length > 10) //if length of entire array is more than 10, only output 10
            {
                length = 10; 
            }

            // Do what is needed to obtain a C# object containing data you wish to convert to JSON
            List<EventApiFields> eventList = new List<EventApiFields>();
            //Going through data, assigning data into string variables, and adding those to new list to pass back
            for (int i = 0; i < length; i++)
            {
                string title = (string)eventArray["events"]["event"][i]["title"];
                string description = (string)eventArray["events"]["event"][i]["description"];
                string startTime = (string)eventArray["events"]["event"][i]["start_time"];
                if (startTime != null)
                {
                    var date = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm:ss",
                                   CultureInfo.InvariantCulture);
                    startTime = date.ToString("MM/dd/yyyy hh:mm tt");
                }
                string stopTime = (string)eventArray["events"]["event"][i]["stop_time"];
                if (stopTime != null)
                {
                    var date2 = DateTime.ParseExact(stopTime, "yyyy-MM-dd HH:mm:ss",
                                   CultureInfo.InvariantCulture);
                    stopTime = date2.ToString("MM/dd/yyyy hh:mm tt");
                }
                string country = (string)eventArray["events"]["event"][i]["tz_country"];
                string state = (string)eventArray["events"]["event"][i]["region_name"];
                string city = (string)eventArray["events"]["event"][i]["tz_city"];
                if (city == null)
                {
                    city = location;
                }
                string price = (string)eventArray["events"]["event"][i]["price"];
                if (price == null)
                {
                    price = "Free";
                }
                JToken imageObj = eventArray["events"]["event"][i]["image"];
                string image;
                if (imageObj.HasValues)
                {
                    image = (string)eventArray["events"]["event"][i]["image"]["url"];
                }
                else
                {
                    image = "/Photos/noimageavailble.jpg";
                }
                string link = (string)eventArray["events"]["event"][i]["url"];
                if (description == null)
                {
                    description = "There is currently no description available for this event. ";
                }

                eventList.Add(new EventApiFields() { Title = title, Description = description, StartTime = startTime, StopTime = stopTime, Country = country, City = city, State = state, Price = price, Length = length, ImageURL = image, LinkURL = link });
            }

            return new ContentResult
            {
                // serialize C# object "commits" to JSON using Newtonsoft.Json.JsonConvert
                Content = JsonConvert.SerializeObject(eventList),
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
        }

        public ActionResult SearchExternalEvents()
        {
            string keywords = Request["keyword"].ToString();
            string location = Request["location"].ToString();
            string newUrlName = string.Format("http://api.eventful.com/json/events/search?keywords={0}&location={1}&page_size=50&include=price&include=tz_city&app_key=QhMNW3GgHB8WJZht", keywords, location);
            System.Diagnostics.Debug.WriteLine("new url name: " + newUrlName);
            string json = SendRequest(newUrlName);
            JObject eventArray = JObject.Parse(json);
            int length = (int)eventArray["total_items"]; //total number in array of events for location
            if (length > 10) //if length of entire array is more than 10, only output 10
            {
                length = 10;
            }

            // Do what is needed to obtain a C# object containing data you wish to convert to JSON
            List<EventApiFields> eventList = new List<EventApiFields>();
            //Going through data, assigning data into string variables, and adding those to new list to pass back
            for (int i = 0; i < length; i++)
            {
                string title = (string)eventArray["events"]["event"][i]["title"];
                string description = (string)eventArray["events"]["event"][i]["description"];
                string startTime = (string)eventArray["events"]["event"][i]["start_time"];
                string stopTime = (string)eventArray["events"]["event"][i]["stop_time"];
                string country = (string)eventArray["events"]["event"][i]["tz_country"];
                string state = (string)eventArray["events"]["event"][i]["region_name"];
                string city = (string)eventArray["events"]["event"][i]["tz_city"];
                if (city == null)
                {
                    city = location;
                }
                string price = (string)eventArray["events"]["event"][i]["price"];
                if (price == null)
                {
                    price = "Free";
                }
                JToken imageObj = eventArray["events"]["event"][i]["image"];
                string image;
                if (imageObj.HasValues)
                {
                    image = (string)eventArray["events"]["event"][i]["image"]["url"];
                }
                else
                {
                    image = "/Photos/noimageavailble.jpg";
                }
                string link = (string)eventArray["events"]["event"][i]["url"];
                if (description == null)
                {
                    description = "There is currently no description available for this event. ";
                }

                eventList.Add(new EventApiFields() { Title = title, Description = description, StartTime = startTime, StopTime = stopTime, Country = country, City = city, State = state, Price = price, Length = length, ImageURL = image, LinkURL = link });
            }

            return new ContentResult
            {
                // serialize C# object "commits" to JSON using Newtonsoft.Json.JsonConvert
                Content = JsonConvert.SerializeObject(eventList),
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DESCRIPTION,COUNTRY,STATE,CITY,STREETADDRESS,ZIPCODE,STARTDATE,STARTTIME,ENDDATE,ENDTIME")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DESCRIPTION,COUNTRY,STATE,CITY,STREETADDRESS,ZIPCODE,STARTDATE,STARTTIME,ENDDATE,ENDTIME")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
