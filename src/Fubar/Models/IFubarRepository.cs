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
        void AddProduct(Product newProduct);
    }
}