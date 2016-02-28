using System.Collections.Generic;

namespace Fubar.Models
{
    public interface ISeverityRepository
    {
        IEnumerable<Severity> GetAllSeverities();
        void AddSeverity(Severity newSeverity);
        bool SaveAll();
    }
}