using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fubar.Models
{
    public class ProductRepository : IProductRepository
    {
        private TicketContext _context;
        private ILogger<ProductRepository> _logger;

        public ProductRepository(TicketContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
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

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}