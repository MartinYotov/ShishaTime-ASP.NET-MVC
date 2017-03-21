using ShishaTime.Models;

namespace ShishaTime.Services.Contracts
{
    public interface IBarsService
    {
        ShishaBar GetBarById(int id);

        void AddBar(ShishaBar bar);
    }
}
