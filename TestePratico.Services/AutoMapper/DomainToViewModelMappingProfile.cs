using AutoMapper;
using AutoMapper.Internal;

namespace TestePratico.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base(nameof(DomainToViewModelMappingProfile))
        {
            CreateMap<Domain.Entities.Person, Services.Person>();

            CreateMap<Domain.Entities.UF, Services.PersonUF>();
            CreateMap<Domain.Entities.UF, Services.UF>();

            this.Internal().ForAllMaps((typeMap, mappingExpression) =>
                mappingExpression.ForMember("Id", o => o.MapFrom(typeMap.SourceType.Name + "Id"))
            );
        }
    }
}
