using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Services.Contracts
{
    public interface IRatingService
    {
        int GetUserRating(int barId, string userId);

        double UpdateBarRating(int barId);

        void AddRating(Rating rating);
    }
}
