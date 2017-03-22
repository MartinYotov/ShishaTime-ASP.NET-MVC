using ShishaTime.Data.Contracts;
using ShishaTime.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShishaTime.Models;
using System.Data.Entity;

namespace ShishaTime.Services
{
    public class ReviewsService : IReviewsService
    {
        private IShishaTimeData data;

        public ReviewsService(IShishaTimeData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Data cannot be null.");
            }

            this.data = data;
        }

        public IEnumerable<Review> GetBarReviews(int barId)
        {
            return data.Reviews.All
                .Where(b => b.BarId == barId)
                .Include(x => x.User)
                .ToList();
        }

        public void AddReview(int barId, Review review)
        {
            var bar = data.Bars.GetById(barId);
            bar.Reviews.Add(review);
            data.SaveChanges();
        }
    }
}