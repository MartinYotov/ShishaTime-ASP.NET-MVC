using ShishaTime.Common.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Common.Providers
{
    public class PathProvider : IPathProvider
    {
        public string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }
    }
}
