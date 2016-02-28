using System.Collections.Generic;

namespace Fubar.Models
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAllStatuses();
        void AddStatus(Status newStatus);
        bool SaveAll();
    }
}