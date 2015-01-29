using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOFT331.ViewModels;
using SOFT331.Models;

namespace SOFT331.Controllers
{
    public class TicketStatisticsController : BaseController
    {
        // GET: Tickets/Statistics
        // TODO: change route
        public ActionResult Index()
        {
            TicketStatisticsViewModel viewModel = new TicketStatisticsViewModel();

            // Simply return all tickets as there are no search params
            viewModel.Tickets = db.Tickets.ToList();

            // Populate fares and trains lists
            viewModel.FareList = db.Fares.ToList();
            viewModel.TrainList = db.Trains.ToList();

            return View(viewModel);
        }

        // POST: Tickets/Statistics
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TicketStatisticsViewModel viewModel)
        {
            // Query object
            IQueryable<Ticket> query = db.Tickets;

            // Show newest tickets first
            query = query.OrderBy(t => t.Id);

            // Build the query based on form input
            if (viewModel.FareId != null)
            {
                query = query.Where(t => t.FareId == viewModel.FareId);
            }

            if (viewModel.TrainId != null)
            {
                query = query.Where(t => t.Timetable.TrainId == viewModel.TrainId);
            }

            if (viewModel.WheelchairOnly)
            {
                query = query.Where(t => t.Wheelchair == true);
            }

            if (viewModel.DisabilitySupportRequestOnly)
            {
                query = query.Where(t => t.DisabilitySupportRequest != null);
            }

            if (viewModel.FromDate != null)
            {
                query = query.Where(t => t.Timetable.Date >= viewModel.FromDate);
            }

            if (viewModel.ToDate != null)
            {
                query = query.Where(t => t.Timetable.Date <= viewModel.ToDate);
            }

            // Ticket search results
            viewModel.Tickets = query.ToList();

            // Populate fares and trains lists
            viewModel.FareList = db.Fares.ToList();
            viewModel.TrainList = db.Trains.ToList();

            return View(viewModel);
        }
    }
}