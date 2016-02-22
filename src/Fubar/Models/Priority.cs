﻿using System;
using System.Collections.Generic;

namespace Fubar.Models
{
    public class Priority
    {
        public Priority()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}