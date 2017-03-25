using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Models
{
    public class ShishaBar
    {
        private ICollection<Review> reviews;
        private ICollection<Rating> ratings;
        private ICollection<User> usersWhoFollowed;

        public ShishaBar()
        {
            this.reviews = new HashSet<Review>();
            this.ratings = new HashSet<Rating>();
            this.usersWhoFollowed = new HashSet<User>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public string ImagePathBig { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Address { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public double RatingValue { get; set; }

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

        public virtual ICollection<User> UsersWhoFollowed
        {
            get
            {
                return this.usersWhoFollowed;
            }

            set
            {
                this.usersWhoFollowed = value;
            }
        }
    }
}
