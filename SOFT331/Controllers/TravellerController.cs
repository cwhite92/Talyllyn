using SOFT331.Models;
using SOFT331.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOFT331.Controllers
{
    public class TravellerController : BaseController
    {
        public ActionResult Book(int year, int month, int day)
        {
            DateTime requestedDate = new DateTime(year, month, day);

            // Double check that the user isn't trying to book for today or the past
            if (requestedDate <= DateTime.Today)
            {
                return RedirectToAction("Index", "Home");
            }

            TravellerBookingViewModel viewModel = new TravellerBookingViewModel();

            var results = db.Timetables.Where(t => t.Date == requestedDate);

            // If no timetable exists for this date redirect to index so the user may select a date that does exist
            if (results.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            viewModel.Timetable = results.First();
            viewModel.TimetableId = viewModel.Timetable.Id;

            // Stuff to populate form elements
            viewModel.FareList = new SelectList(db.Fares, "Id", "PrettyName");
            viewModel.DiscountList = new SelectList(db.Discounts, "Id", "Name");

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(int year, int month, int day, TravellerBookingViewModel viewModel)
        {
            // We can do this here without checking if the timetable exists as the user won't get to POST to
            // this action without the timetable already existing
            DateTime requestedDate = new DateTime(year, month, day);
            var results = db.Timetables.Where(t => t.Date == requestedDate);
            viewModel.Timetable = results.First();
            viewModel.TimetableId = viewModel.Timetable.Id;

            if(ModelState.IsValid)
            {
                db.Tickets.Add(new Ticket
                {
                    TimetableId = viewModel.TimetableId,
                    FareId = viewModel.FareId,
                    DiscountId = viewModel.DiscountId,
                    Wheelchair = viewModel.Wheelchair,
                    GiftaidName = viewModel.GiftaidName,
                    GiftaidAddressFirstLine = viewModel.GiftaidAddressFirstLine,
                    GiftaidPostcode = viewModel.GiftaidPostcode
                });
                db.SaveChanges();
                // TODO: redirect to confirmation page
                return RedirectToAction("Confirmation");
            }

            // Stuff to populate form elements
            viewModel.FareList = new SelectList(db.Fares, "Id", "PrettyName");
            viewModel.DiscountList = new SelectList(db.Discounts, "Id", "Name");

            return View(viewModel);
        }

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}