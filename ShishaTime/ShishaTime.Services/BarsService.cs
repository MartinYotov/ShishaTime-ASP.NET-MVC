using System;
using System.Collections.Generic;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;

namespace ShishaTime.Services
{
    public class BarsService : IBarsService
    {
        private IShishaTimeData data;

        public BarsService(IShishaTimeData data)
        {
            this.data = data;
        }

        public void AddBar(ShishaBar bar)
        {
            this.data.Bars.Add(bar);
            this.data.SaveChanges();
        }       
    }
}
