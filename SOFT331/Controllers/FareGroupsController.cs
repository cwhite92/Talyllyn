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
    public class FareGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FareGroups
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.FareGroups.ToList());
        }

        // GET: FareGroups/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FareGroup fareGroup = db.FareGroups.Find(id);
            if (fareGroup == null)
            {
                return HttpNotFound();
            }
            return View(fareGroup);
        }

        // GET: FareGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FareGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FareGroup fareGroup)
        {
            if (ModelState.IsValid)
            {
                db.FareGroups.Add(fareGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fareGroup);
        }

        // GET: FareGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FareGroup fareGroup = db.FareGroups.Find(id);
            if (fareGroup == null)
            {
                return HttpNotFound();
            }
            return View(fareGroup);
        }

        // POST: FareGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FareGroup fareGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fareGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fareGroup);
        }

        // GET: FareGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FareGroup fareGroup = db.FareGroups.Find(id);
            if (fareGroup == null)
            {
                return HttpNotFound();
            }
            return View(fareGroup);
        }

        // POST: FareGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FareGroup fareGroup = db.FareGroups.Find(id);
            db.FareGroups.Remove(fareGroup);
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
