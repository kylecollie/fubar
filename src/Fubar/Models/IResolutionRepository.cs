using System.Collections.Generic;

namespace Fubar.Models
{
    public interface IResolutionRepository
    {
        IEnumerable<Resolution> GetAllResolutions();
        void AddResolution(Resolution newResolution);
        bool SaveAll();
    }
}