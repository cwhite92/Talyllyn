using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOFT331.Models;

namespace SOFT331.ViewModels
{
    public class TicketStatisticsViewModel
    {
        // Parameters to narrow down search results by
        [Display(Name = "Fare Type")]
        public int? FareId { get; set; }

        [Display(Name = "Train")]
        public int? TrainId { get; set; }

        [Display(Name = "From"), Column(TypeName = "Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To"), Column(TypeName = "Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Wheelchair Requested")]
        public bool WheelchairOnly { get; set; }

        [Display(Name = "Disability Requests Only")]
        public bool DisabilitySupportRequestOnly { get; set; }

        // Used to populate the search parameters and for ticket breakdown
        public List<Fare> FareList { get; set; }
        public List<Train> TrainList { get; set; }

        // The resulting tickets from the user's search parameters
        public List<Ticket> Tickets { get; set; }

        // Calculates how many of each type of ticket was purchased
        public Dictionary<string, int> TicketBreakdown
        {
            get
            {
                // Aggregate over tickets collection and construct a dictionary where the key is
                // the fare name and the value is the count of that fare
                // Side note: I bloody love C#
                return this.Tickets.Aggregate(new Dictionary<string, int>(), (d, t) => {
                    d[t.Fare.PrettyName] = (d.ContainsKey(t.Fare.PrettyName)) ? d[t.Fare.PrettyName] + 1 : 1;
                    return d;
                });
            }
        }

        // Returns the total value of sales of all tickets
        public string TotalSales
        {
            get
            {
                return string.Format("£{0}", this.Tickets.Sum(t => t.TotalPrice));
            }
        }
    }
}