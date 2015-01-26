using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOFT331.ViewModels
{
    public class BaseEventViewModel
    {
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    public class EventCreateViewModel : BaseEventViewModel
    {
        public int Id { get; set; }
    }

    public class EventIndexViewModel : BaseEventViewModel
    {

    }

    public class EventDetailsViewModel : BaseEventViewModel
    {

    }

    public class EventEditViewModel : EventCreateViewModel
    {

    }

    public class EventDeleteViewModel : BaseEventViewModel
    {

    }
}