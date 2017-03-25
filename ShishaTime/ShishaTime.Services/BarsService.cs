using System;
using System.Collections.Generic;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using System.Linq;

namespace ShishaTime.Services
{
    public class BarsService : IBarsService
    {
        private IShishaTimeData data;

        public BarsService(IShishaTimeData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Data cannot be null.");
            }

            this.data = data;
        }

        public ShishaBar GetBarById(int id)
        {
            return this.data.Bars.GetById(id);
        }

        public void AddBar(ShishaBar bar)
        {
            this.data.Bars.Add(bar);
            this.data.SaveChanges();
        }

        public IEnumerable<ShishaBar> GetTopRated(int count)
        {
            return this.data.Bars.All
                .OrderByDescending(b => b.RatingValue)
                .Take(count)
                .ToList();
        }
    }
}
