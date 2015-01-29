using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOFT331.ViewModels;

namespace SOFT331.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            // Load all of the timetable dates into a select list
            TravellerBookingViewModel viewModel = new TravellerBookingViewModel();
            viewModel.Timetables = new SelectList(db.Timetables.ToList(), "Id", "Date");

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TravellerBookingViewModel viewModel)
        {
            // If the date entered is valid, redirect to booking form
            if (ModelState.IsValid)
            {
                viewModel.Timetable = db.Timetables.Find(viewModel.TimetableId);
                return Redirect(string.Format("/Traveller/Book/{0}", viewModel.Timetable.Date.ToString("dd/MM/yyyy")));
            }

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}