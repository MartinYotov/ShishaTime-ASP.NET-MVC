using ShishaTime.Common.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShishaTime.Common.Providers
{
    public class CacheProvider : ICacheProvider
    {
        public object GetItem(string key)
        {
            return HttpContext.Current.Cache[key];
        }

        public void SaveInCache(string key, object value, int minutes)
        {
            HttpContext.Current.Cache.Insert(key, 
                                             value, 
                                             null, 
                                             DateTime.MaxValue, 
                                             TimeSpan.FromMinutes(minutes));
        }
    }
}
