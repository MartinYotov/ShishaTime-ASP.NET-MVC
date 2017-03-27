using ShishaTime.Models;
using System.Collections.Generic;

namespace ShishaTime.Services.Contracts
{
    public interface IBarsService
    {
        ShishaBar GetBarById(int id);

        void AddBar(ShishaBar bar);

        IEnumerable<ShishaBar> GetTopRated(int count);

        IEnumerable<ShishaBar> GetBarsWithPaging(out int count, int page, int pageSize);
    }
}
