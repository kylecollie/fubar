using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fubar.Models
{
    public class FubarRepository : IFubarRepository
    {
        private TicketContext _context;

        public FubarRepository(TicketContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _context.Tickets.OrderBy(t => t.ID).ToList();
        }

        public IEnumerable<Ticket> GetAllTicketsUnresolved()
        {
            return _context.Tickets
                .Where(t => t.ResolutionId != null)
                .OrderBy(t => t.ID)
                .ToList();
        }
    }
}
