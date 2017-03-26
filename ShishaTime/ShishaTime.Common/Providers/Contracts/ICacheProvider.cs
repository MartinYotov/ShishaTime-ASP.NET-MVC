using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Common.Providers.Contracts
{
    public interface ICacheProvider
    {
        object GetItem(string key);

        void SaveInCache(string key, object value, int minutes);
    }
}
