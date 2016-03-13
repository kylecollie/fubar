using Microsoft.Data.Entity;
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

        public void AddProduct(Product newProduct)
        {
            _context.Add(newProduct);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return _context.Products.OrderBy(p => p.ID).ToList();
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

        public  void UpdateProduct(Product thisProduct)
        {
            _context.Entry(thisProduct).State = EntityState.Modified;
        }
    }
}
