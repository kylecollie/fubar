using System.Collections.Generic;

namespace Fubar.Models
{
    public interface IFubarRepository
    {
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetAllTicketsUnresolved();
        IEnumerable<Ticket> GetAllTicketsResolved();
        void AddTicket(Ticket newTicket);
        bool SaveAll();
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product newProduct);
        void UpdateProduct(Product thisProduct);
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category newCategory);
        IEnumerable<Severity> GetAllSeverities();
        void AddSeverity(Severity newSeverity);
        IEnumerable<Priority> GetAllPriorities();
        void AddPriority(Priority newPriority);
        IEnumerable<Resolution> GetAllResolutions();
        void AddResolution(Resolution newResolution);
        IEnumerable<Status> GetAllStatuses();
        void AddStatus(Status newStatus);
    }
}