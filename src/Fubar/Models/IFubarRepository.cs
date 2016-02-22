using System.Collections.Generic;

namespace Fubar.Models
{
    public interface IFubarRepository
    {
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetAllTicketsUnresolved();
    }
}