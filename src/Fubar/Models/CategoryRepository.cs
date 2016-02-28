using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fubar.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private TicketContext _context;
        private ILogger<CategoryRepository> _logger;

        public CategoryRepository(TicketContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddCategory(Category newCategory)
        {
            _context.Add(newCategory);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                return _context.Categories.OrderBy(c => c.ID).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get categories from database", ex);
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
