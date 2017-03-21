using ShishaTime.Models;
using ShishaTime.Web.AutoMapper;
using System.Collections.Generic;
using AutoMapper;

namespace ShishaTime.Web.Models
{
    public class BarViewModel : IMapFrom<ShishaBar>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string ImagePathBig { get; set; }

        public string Region { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<User> UsersWhoFollowed { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<ShishaBar, BarViewModel>()
                .ForMember(d => d.Region, src => src.MapFrom(s => s.Region.Name));
        }
    }
}