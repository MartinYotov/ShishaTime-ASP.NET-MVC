using ShishaTime.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using ShishaTime.Models;
using ShishaTime.Data.Contracts;

namespace ShishaTime.Services
{
    public class RegionsService : IRegionsService
    {
        private IShishaTimeData data;

        public RegionsService(IShishaTimeData data)
        {
            this.data = data;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            return data.Regions.All.ToList();
        }
    }
}
