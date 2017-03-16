using Microsoft.AspNet.Identity.EntityFramework;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShishaTime.Data
{
    public class ShishaTimeDbContext : IdentityDbContext<User>, IShishaTimeDbContext
    {
        public ShishaTimeDbContext() : base("ShishaTime")
        {
            Database.SetInitializer<ShishaTimeDbContext>(new CreateDatabaseIfNotExists<ShishaTimeDbContext>());
        }
        
        public virtual IDbSet<ShishaBar> Bars { get; set; }

        public virtual IDbSet<Region> Regions { get; set; }

        public virtual IDbSet<Review> Reviews { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public static ShishaTimeDbContext Create()
        {
            return new ShishaTimeDbContext();
        }

        // TODO: deicide how to implement method
        IDbSet<T> IShishaTimeDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ShishaBar>().HasMany(x => x.Ratings);
            //modelBuilder.Entity<Rating>().
            modelBuilder.Entity<User>().HasMany(x => x.FavouriteBars).WithMany(x => x.UsersWhoFollowed);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
