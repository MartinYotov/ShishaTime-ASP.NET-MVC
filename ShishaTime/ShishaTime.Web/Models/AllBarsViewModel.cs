using AutoMapper;
using ShishaTime.Models;
using ShishaTime.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShishaTime.Web.Models
{
    public class AllBarsViewModel : IMapFrom<ShishaBar>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Region { get; set; }

        public double RatingValue { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<ShishaBar, AllBarsViewModel>()
                .ForMember(d => d.Region, src => src.MapFrom(s => s.Region.Name))
                .ForMember(d => d.Image, src => src.MapFrom(s => s.ImagePathBig.Substring(1)));
        }
    }
}