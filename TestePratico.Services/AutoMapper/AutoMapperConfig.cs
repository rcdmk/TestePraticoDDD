using AutoMapper;

namespace TestePratico.Services.AutoMapper
{
    public class AutoMapperConfig : MapperConfiguration
    {
        public AutoMapperConfig(MapperConfigurationExpression confExpression) : base(confExpression)
        {
            confExpression.AddProfile<StandardTypeMappingProfile>();
            confExpression.AddProfile<DomainToViewModelMappingProfile>();
            confExpression.AddProfile<ViewModelToDomainMappingProfile>();
        }
    }
}
