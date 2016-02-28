using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fubar.Models
{
    public class ResolutionRepository : IResolutionRepository
    {
        private TicketContext _context;
        private ILogger<ResolutionRepository> _logger;

        public ResolutionRepository(TicketContext context, ILogger<ResolutionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void AddResolution(Resolution newResolution)
        {
            _context.Add(newResolution);
        }

        public IEnumerable<Resolution> GetAllResolutions()
        {
            try
            {
                return _context.Resolutions.OrderBy(r => r.ID).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get resolutions from database.", ex);
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
