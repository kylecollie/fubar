using System;
using System.Collections.Generic;

namespace Fubar.Models
{
    public class Resolution
    {
        public Resolution()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}