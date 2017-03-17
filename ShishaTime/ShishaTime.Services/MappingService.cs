﻿using AutoMapper;
using ShishaTime.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Services
{
    public class MappingService : IMappingService
    {
        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
