﻿using System;
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
        
    }

    public class EventIndexViewModel : BaseEventViewModel
    {
        public int Id { get; set; }
    }

    public class EventDetailsViewModel : BaseEventViewModel
    {

    }

    public class EventEditViewModel : BaseEventViewModel
    {
        public int Id { get; set; }
    }

    public class EventDeleteViewModel : BaseEventViewModel
    {

    }
}