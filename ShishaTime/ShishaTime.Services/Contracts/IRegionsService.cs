using ShishaTime.Models;
using System.Collections.Generic;

namespace ShishaTime.Services.Contracts
{
    public interface IRegionsService
    {
        IEnumerable<Region> GetAllRegions();
    }
}
