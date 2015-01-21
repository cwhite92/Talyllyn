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
    public class TimetablesController : BaseController
    {
        // GET: Timetables
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Timetables.ToList());
        }

        // GET: Timetables/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Timetable timetable = db.Timetables.Find(id);

            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // GET: Timetables/Create
        public ActionResult Create()
        {
            TimetablesCreateViewModel model = new TimetablesCreateViewModel
            {
                Timetable = new Timetable(),
                TrainList = new SelectList(db.Trains, "Id", "Name"),
                StationList = new SelectList(db.Stations, "Id", "Name")
            };

            return View(model);
        }

        // POST: Timetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimetablesCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Timetables.Add(viewModel.Timetable);

                for (int i = 0; i < viewModel.StationTimetables.Count; i++)
                {
                    // Only add the entry if station ID isn't null, this is when a user doesn't fill out the entire form
                    if (viewModel.StationTimetables[i].StationId != null)
                    {
                        viewModel.StationTimetables[i].TimetableId = viewModel.Timetable.Id;
                        db.StationTimetables.Add(viewModel.StationTimetables[i]);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Timetables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: Timetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timetable timetable = db.Timetables.Find(id);
            db.Timetables.Remove(timetable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
