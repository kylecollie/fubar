using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fubar.Models
{
    public class SeverityRepository : ISeverityRepository
    {
        private TicketContext _context;
        private ILogger<SeverityRepository> _logger;

        public SeverityRepository(TicketContext context, ILogger<SeverityRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddSeverity(Severity newSeverity)
        {
            _context.Add(newSeverity);
        }

        public IEnumerable<Severity> GetAllSeverities()
        {
            try
            {
                return _context.Severities.OrderBy(s => s.ID).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get severities from database.", ex);
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
