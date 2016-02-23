using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fubar.Models
{
    public class FubarRepository : IFubarRepository
    {
        private TicketContext _context;
        private ILogger<FubarRepository> _logger;

        public FubarRepository(TicketContext context, ILogger<FubarRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            try
            {
                return _context.Tickets.OrderBy(t => t.ID).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get tickets from database", ex);
                return null;
            }
        }

        public IEnumerable<Ticket> GetAllTicketsResolved()
        {
            try
            {
                return _context.Tickets
                        .Where(t => t.ResolutionId != null)
                        .OrderBy(t => t.ID)
                        .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get tickets from database", ex);
                return null;
            }
        }

        public IEnumerable<Ticket> GetAllTicketsUnresolved()
        {
            try
            {
                return _context.Tickets
                        .Where(t => t.ResolutionId == null)
                        .OrderBy(t => t.ID)
                        .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get tickets from database", ex);
                return null;
            }
        }
    }
}
