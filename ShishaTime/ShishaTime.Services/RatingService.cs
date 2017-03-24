using ShishaTime.Services.Contracts;
using ShishaTime.Models;
using ShishaTime.Data.Contracts;
using System.Linq;

namespace ShishaTime.Services
{
    public class RatingService : IRatingService
    {
        private IShishaTimeData data;

        public RatingService(IShishaTimeData data)
        {
            this.data = data;
        }

        public int GetUserRating(int barId, string userId)
        {
            var userRating = data.Ratings.All
                .FirstOrDefault(r => r.BarId == barId &&
                                     r.UserId == userId);

            return userRating != null ? userRating.Value : 0;               
        }

        public void AddRating(Rating rating)
        {
            var userRating = data.Ratings.All
                .FirstOrDefault(r => r.BarId == rating.BarId &&
                                     r.UserId == rating.UserId);

            if (userRating != null)
            {
                userRating.Value = rating.Value;
            }
            else
            {
                this.data.Ratings.Add(rating);
            }

            this.data.SaveChanges();
        }

        public double UpdateBarRating(int barId)
        {
            var bar = this.data.Bars.GetById(barId);
            var ratingsCount = bar.Ratings.Count;
            var sum = bar.Ratings.Sum(r => r.Value);

            bar.RatingValue = (double)sum / ratingsCount;

            this.data.SaveChanges();

            return bar.RatingValue;
        }
    }
}
