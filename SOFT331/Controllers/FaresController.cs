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
    [Authorize(Roles = "Admin")]
    public class FaresController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Fares
        [AllowAnonymous]
        public ActionResult Index()
        {
            var fares = db.Fares.Include(f => f.FareGroup);
            return View(fares.ToList());
        }

        // GET: Fares/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fare fare = db.Fares.Find(id);
            if (fare == null)
            {
                return HttpNotFound();
            }
            return View(fare);
        }

        // GET: Fares/Create
        public ActionResult Create()
        {
            ViewBag.FareGroupId = new SelectList(db.FareGroups, "Id", "Name");
            return View();
        }

        // POST: Fares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FareGroupId,Name,Description,Price")] Fare fare)
        {
            if (ModelState.IsValid)
            {
                db.Fares.Add(fare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FareGroupId = new SelectList(db.FareGroups, "Id", "Name", fare.FareGroupId);
            return View(fare);
        }

        // GET: Fares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fare fare = db.Fares.Find(id);
            if (fare == null)
            {
                return HttpNotFound();
            }
            ViewBag.FareGroupId = new SelectList(db.FareGroups, "Id", "Name", fare.FareGroupId);
            return View(fare);
        }

        // POST: Fares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FareGroupId,Name,Description,Price")] Fare fare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FareGroupId = new SelectList(db.FareGroups, "Id", "Name", fare.FareGroupId);
            return View(fare);
        }

        // GET: Fares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fare fare = db.Fares.Find(id);
            if (fare == null)
            {
                return HttpNotFound();
            }
            return View(fare);
        }

        // POST: Fares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fare fare = db.Fares.Find(id);
            db.Fares.Remove(fare);
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
