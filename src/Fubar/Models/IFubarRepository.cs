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
    }
}