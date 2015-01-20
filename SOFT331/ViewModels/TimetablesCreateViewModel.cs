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
        public Timetable Timetable { get; set; }

        public IList<StationTimetable> StationTimetables { get; set; }

        public SelectList TrainList { get; set; }

        public SelectList StationList { get; set; }
    }
}