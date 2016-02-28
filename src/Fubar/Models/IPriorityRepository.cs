using System.Collections.Generic;

namespace Fubar.Models
{
    public interface IPriorityRepository
    {
      IEnumerable<Priority>  GetAllPriorities();
      void AddPriority(Priority newPriority);
      bool SaveAll();
    }
}