using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Services.Contracts
{
    public interface IMappingService
    {
        T Map<T>(object source);

        TDestination Map<TSource, TDestination>(TSource source);
    }
}
