using SOFT331.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOFT331.ViewModels
{
    public class TimetablesCreateViewModel
    {
        private SelectList stationList;

        // A nice round default number
        public int maximumStops = 10;

        public Timetable Timetable { get; set; }

        public IList<StationTimetable> StationTimetables { get; set; }

        public SelectList TrainList { get; set; }

        public SelectList StationList
        {
            get
            {
                return stationList;
            }
            set
            {
                // Maximum number of stations for each timetable.
                // Set to double the number of stations in the database - 1.
                // This is enough for a train to go from the first station
                // to the last and back again.
                maximumStops = (value.Count() * 2) - 1;

                stationList = value;
            }
        }
    }
}