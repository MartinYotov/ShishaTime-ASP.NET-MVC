using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Data.Contracts
{
    public interface IShishaTimeData
    {
        IEntityFrameworkRepository<ShishaBar> Bars { get; }

        IEntityFrameworkRepository<User> Users { get; }

        IEntityFrameworkRepository<Region> Regions { get; }

        IEntityFrameworkRepository<Review> Reviews { get; }

        IEntityFrameworkRepository<Rating> Ratings { get; }

        void SaveChanges();
    }
}
