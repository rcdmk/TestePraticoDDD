using AutoMapper;

namespace TestePratico.Web.AutoMapper
{
    public class AutoMapperConfig : MapperConfiguration
    {
        public AutoMapperConfig(MapperConfigurationExpression configurationExpression) : base(configurationExpression)
        {
            configurationExpression.AddProfile<StandardTypeMappingProfile>();
            configurationExpression.AddProfile<DomainToViewModelMappingProfile>();
            configurationExpression.AddProfile<ViewModelToDomainMappingProfile>();
        }
    }
}
