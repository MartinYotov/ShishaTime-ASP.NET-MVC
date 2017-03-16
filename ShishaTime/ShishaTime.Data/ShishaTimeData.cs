using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Data
{
    public class ShishaTimeData : IShishaTimeData
    {
        private readonly IShishaTimeDbContext dbContext;

        public ShishaTimeData(
            IShishaTimeDbContext dbContext,
            IEntityFrameworkRepository<ShishaBar> barsRepository,
            IEntityFrameworkRepository<User> usersRepository,
            IEntityFrameworkRepository<Region> regionsRepository,
            IEntityFrameworkRepository<Review> reviewsRepository,
            IEntityFrameworkRepository<Rating> ratingsRepository)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext cannot be null.");
            }

            if (barsRepository == null)
            {
                throw new ArgumentNullException("Bars repository cannot be null.");
            }

            if (usersRepository == null)
            {
                throw new ArgumentNullException("Users repository cannot be null.");
            }

            if (regionsRepository == null)
            {
                throw new ArgumentNullException("Regions repository cannot be null.");
            }

            if (reviewsRepository == null)
            {
                throw new ArgumentNullException("Reviews repository cannot be null.");
            }

            if (ratingsRepository == null)
            {
                throw new ArgumentNullException("Ratings repository cannot be null.");
            }

            this.dbContext = dbContext;
            this.Bars = barsRepository;
            this.Users = usersRepository;          
            this.Regions = regionsRepository;
            this.Reviews = reviewsRepository;
            this.Ratings = ratingsRepository;
        }

        public IEntityFrameworkRepository<ShishaBar> Bars { get; }

        public IEntityFrameworkRepository<User> Users { get; }

        public IEntityFrameworkRepository<Region> Regions { get; }

        public IEntityFrameworkRepository<Review> Reviews { get; }

        public IEntityFrameworkRepository<Rating> Ratings { get; }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
