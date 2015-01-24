using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SOFT331.Models;
using SOFT331.ViewModels;

namespace SOFT331.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventsController : BaseController
    {
        [AllowAnonymous]
        // GET: Events
        public ActionResult Index()
        {
            List<EventIndexViewModel> events = new List<EventIndexViewModel>();

            foreach (Event @event in db.Events)
            {
                events.Add(new EventIndexViewModel
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    Description = @event.Description
                });
            }

            return View(events);
        }

        [AllowAnonymous]
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

            EventDetailsViewModel viewModel = new EventDetailsViewModel();
            viewModel.Name = @event.Name;
            viewModel.Description = @event.Description;

            return View(viewModel);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(new Event
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
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

            EventEditViewModel viewModel = new EventEditViewModel();
            viewModel.Name = @event.Name;
            viewModel.Description = @event.Description;

            return View(viewModel);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Event @event = db.Events.Find(viewModel.Id);

                @event.Name = viewModel.Name;
                @event.Description = viewModel.Description;
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
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

            EventDeleteViewModel viewModel = new EventDeleteViewModel();
            viewModel.Name = @event.Name;
            viewModel.Description = @event.Description;

            return View(viewModel);
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
    }
}
