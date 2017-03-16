using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Data.Contracts
{
    public interface IShishaTimeDbContext
    {
        IDbSet<ShishaBar> Bars { get; set; }

        IDbSet<Region> Regions { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
