using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fubar.Models
{
    public class PriorityRepository : IPriorityRepository
    {
        private TicketContext _context;
        private ILogger<PriorityRepository> _logger;

        public PriorityRepository(TicketContext context, ILogger<PriorityRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddPriority(Priority newPriority)
        {
            _context.Add(newPriority);
        }

        public IEnumerable<Priority> GetAllPriorities()
        {
            try
            {
                return _context.Priorities.OrderBy(p => p.ID).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get priorities from database", ex);
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
