﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Common.Providers.Contracts
{
    public interface IServerProvider
    {
        string MapPath(string path);
    }
}