using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddTicket(Ticket newTicket)
        {
            _context.Add(newTicket);
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

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        #region Product
        public void AddProduct(Product newProduct)
        {
            _context.Add(newProduct);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return _context.Products.OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get products from database", ex);
                return null;
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                return _context.Products.Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get product from database", ex);
                return null;
            }
        }

        public void UpdateProduct(Product thisProduct)
        {
            _context.Entry(thisProduct).State = EntityState.Modified;
        }
        #endregion

        #region Category
        public void AddCategory(Category newCategory)
        {
            _context.Add(newCategory);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                return _context.Categories.OrderBy(c => c.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get categories from database", ex);
                return null;
            }
        }

        #endregion

        #region Severity
        public void AddSeverity(Severity newSeverity)
        {
            _context.Add(newSeverity);
        }

        public IEnumerable<Severity> GetAllSeverities()
        {
            try
            {
                return _context.Severities.OrderBy(s => s.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get severities from database.", ex);
                return null;
            }
        }
        #endregion

        #region Priority
        public void AddPriority(Priority newPriority)
        {
            _context.Add(newPriority);
        }

        public IEnumerable<Priority> GetAllPriorities()
        {
            try
            {
                return _context.Priorities.OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get priorities from database", ex);
                return null;
            }
        }
        #endregion

        #region Resolution
        public void AddResolution(Resolution newResolution)
        {
            _context.Add(newResolution);
        }

        public IEnumerable<Resolution> GetAllResolutions()
        {
            try
            {
                return _context.Resolutions.OrderBy(r => r.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get resolutions from database.", ex);
                return null;
            }
        }
        #endregion

        #region Status
        public void AddStatus(Status newStatus)
        {
            _context.Add(newStatus);
        }

        public IEnumerable<Status> GetAllStatuses()
        {
            try
            {
                return _context.Statuses.OrderBy(s => s.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get statuses from database.", ex);
                return null;
            }
        }
        #endregion
    }
}
