using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Services.Contracts
{
    public interface IReviewsService
    {
        IEnumerable<Review> GetBarReviews(int barId);

        void AddReview(int barId, Review review);
    }
}
