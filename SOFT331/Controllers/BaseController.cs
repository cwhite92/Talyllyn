using SOFT331.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOFT331.Controllers
{
    public class BaseController : Controller
    {
        protected DatabaseContext db { get; set; }

        public BaseController()
        {
            db = new DatabaseContext();
        }

        /// <summary>
        /// Disposes of the database context at the end of a request cycle.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}