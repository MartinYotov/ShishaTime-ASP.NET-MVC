using AutoMapper;

namespace ShishaTime.Web.AutoMapper
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression config);
    }
}