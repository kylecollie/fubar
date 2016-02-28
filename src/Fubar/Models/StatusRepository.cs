using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fubar.Models
{
    public class StatusRepository : IStatusRepository
    {
        private TicketContext _context;
        private ILogger<StatusRepository> _logger;

        public StatusRepository(TicketContext context, ILogger<StatusRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddStatus(Status newStatus)
        {
            _context.Add(newStatus);
        }

        public IEnumerable<Status> GetAllStatuses()
        {
            try
            {
                return _context.Statuses.OrderBy(s => s.ID).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get statuses from database.", ex);
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
