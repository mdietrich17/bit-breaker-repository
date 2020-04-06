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
using SimplySeniors.Attributes;

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
        new SelectListItem() { Text="District of Columbia", Value="District of Columbia"},
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

[CustomAuthorize]
    public class EventsController : Controller
    {
        private EventContext db = new EventContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
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
