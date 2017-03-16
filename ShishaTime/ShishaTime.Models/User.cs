using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShishaTime.Models
{
    public class User : IdentityUser
    {
        private ICollection<ShishaBar> favouriteBars;
        private ICollection<Review> reviews;
        private ICollection<Rating> ratings;

        public User()
        {
            this.favouriteBars = new HashSet<ShishaBar>();
            this.reviews = new HashSet<Review>();
            this.ratings = new HashSet<Rating>();
        }

        public virtual ICollection<ShishaBar> FavouriteBars
        {
            get
            {
                return this.favouriteBars;
            }

            set
            {
                this.favouriteBars = value;
            }
        }

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }

        public virtual ICollection<Rating> Ratings
        {
            get
            {
                return this.ratings;
            }

            set
            {
                this.ratings = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
