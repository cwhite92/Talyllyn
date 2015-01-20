using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SOFT331.Models;

namespace SOFT331.Controllers
{
    public class StationTimetablesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: StationTimetables
        public ActionResult Index()
        {
            var stationTimetables = db.StationTimetables.Include(s => s.Station).Include(s => s.Timetable);
            return View(stationTimetables.ToList());
        }

        // GET: StationTimetables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationTimetable stationTimetable = db.StationTimetables.Find(id);
            if (stationTimetable == null)
            {
                return HttpNotFound();
            }
            return View(stationTimetable);
        }

        // GET: StationTimetables/Create
        public ActionResult Create()
        {
            ViewBag.StationId = new SelectList(db.Stations, "Id", "Name");
            ViewBag.TimetableId = new SelectList(db.Timetables, "Id", "Id");
            return View();
        }

        // POST: StationTimetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StationId,TimetableId,Arrival,Departure")] StationTimetable stationTimetable)
        {
            if (ModelState.IsValid)
            {
                db.StationTimetables.Add(stationTimetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StationId = new SelectList(db.Stations, "Id", "Name", stationTimetable.StationId);
            ViewBag.TimetableId = new SelectList(db.Timetables, "Id", "Id", stationTimetable.TimetableId);
            return View(stationTimetable);
        }

        // GET: StationTimetables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationTimetable stationTimetable = db.StationTimetables.Find(id);
            if (stationTimetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationId = new SelectList(db.Stations, "Id", "Name", stationTimetable.StationId);
            ViewBag.TimetableId = new SelectList(db.Timetables, "Id", "Id", stationTimetable.TimetableId);
            return View(stationTimetable);
        }

        // POST: StationTimetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StationId,TimetableId,Arrival,Departure")] StationTimetable stationTimetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationTimetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StationId = new SelectList(db.Stations, "Id", "Name", stationTimetable.StationId);
            ViewBag.TimetableId = new SelectList(db.Timetables, "Id", "Id", stationTimetable.TimetableId);
            return View(stationTimetable);
        }

        // GET: StationTimetables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationTimetable stationTimetable = db.StationTimetables.Find(id);
            if (stationTimetable == null)
            {
                return HttpNotFound();
            }
            return View(stationTimetable);
        }

        // POST: StationTimetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationTimetable stationTimetable = db.StationTimetables.Find(id);
            db.StationTimetables.Remove(stationTimetable);
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
