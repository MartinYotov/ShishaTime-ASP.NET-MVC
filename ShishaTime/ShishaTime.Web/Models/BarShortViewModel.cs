using AutoMapper;
using ShishaTime.Models;
using ShishaTime.Web.AutoMapper;

namespace ShishaTime.Web.Models
{
    public class BarShortViewModel : IMapFrom<ShishaBar>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public double RatingValue { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<ShishaBar, BarShortViewModel>()
                .ForMember(d => d.Image, src => src.MapFrom(s => s.ImagePathBig.Substring(1)));
        }
    }
}