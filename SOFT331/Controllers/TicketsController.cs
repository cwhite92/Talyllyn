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
    [Authorize(Roles = "Admin, Clerk")]
    public class TicketsController : BaseController
    {
        // GET: Tickets
        public ActionResult Index()
        {
            List<TicketIndexViewModel> tickets = new List<TicketIndexViewModel>(); 

            foreach(Ticket ticket in db.Tickets.Include(t => t.Discount).Include(t => t.Fare).Include(t => t.Timetable))
            {
                tickets.Add(new TicketIndexViewModel {
                    Id = ticket.Id,
                    Fare = ticket.Fare,
                    Discount = ticket.Discount,
                    Timetable = ticket.Timetable,
                    Wheelchair = ticket.Wheelchair,
                    Ticket = ticket
                });
            }

            return View(tickets);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            TicketCreateViewModel viewModel = new TicketCreateViewModel();
            viewModel.TimetableList = new SelectList(db.Timetables, "Id", "Date");
            viewModel.FareList = new SelectList(db.Fares, "Id", "PrettyName");
            viewModel.DiscountList = db.Discounts.ToList();

            return View(viewModel);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(new Ticket
                {
                    TimetableId = viewModel.TimetableId,
                    FareId = viewModel.FareId,

                    // Discount is optional - if we get a -1 that actually means no discount
                    DiscountId = viewModel.DiscountId == -1 ? null : viewModel.DiscountId,
                    Wheelchair = viewModel.Wheelchair
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.TimetableList = new SelectList(db.Timetables, "Id", "Date");
            viewModel.FareList = new SelectList(db.Fares, "Id", "PrettyName");
            viewModel.DiscountList = db.Discounts.ToList();

            return View(viewModel);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ticket ticket = db.Tickets.Find(id);

            if (ticket == null)
            {
                return HttpNotFound();
            }

            TicketEditViewModel viewModel = new TicketEditViewModel();
            viewModel.TimetableId = ticket.TimetableId;
            viewModel.FareId = ticket.FareId;
            viewModel.DiscountId = ticket.DiscountId;
            viewModel.Wheelchair = ticket.Wheelchair;

            viewModel.TimetableList = new SelectList(db.Timetables, "Id", "Date", viewModel.TimetableId);
            viewModel.FareList = new SelectList(db.Fares, "Id", "PrettyName");
            viewModel.DiscountList = db.Discounts.ToList();

            return View(viewModel);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Ticket ticket = db.Tickets.Find(viewModel.Id);

                ticket.TimetableId = viewModel.TimetableId;
                ticket.FareId = viewModel.FareId;

                // Discount is optional - if we get a -1 that actually means no discount
                ticket.DiscountId = viewModel.DiscountId == -1 ? null : viewModel.DiscountId;
                ticket.Wheelchair = viewModel.Wheelchair;
                db.Entry(ticket).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.TimetableList = new SelectList(db.Timetables, "Id", "Date", viewModel.TimetableId);
            viewModel.FareList = new SelectList(db.Fares, "Id", "PrettyName");
            viewModel.DiscountList = db.Discounts.ToList();
            return View(viewModel);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ticket ticket = db.Tickets.Find(id);

            if (ticket == null)
            {
                return HttpNotFound();
            }

            TicketDeleteViewModel viewModel = new TicketDeleteViewModel();
            viewModel.Timetable = ticket.Timetable;
            viewModel.Fare = ticket.Fare;
            viewModel.Discount = ticket.Discount;
            viewModel.Wheelchair = ticket.Wheelchair;

            return View(viewModel);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
