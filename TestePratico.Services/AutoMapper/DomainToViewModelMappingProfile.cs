using AutoMapper;
using AutoMapper.Internal;

namespace TestePratico.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base(nameof(DomainToViewModelMappingProfile))
        {
            CreateMap<Domain.Entities.Pessoa, Services.Pessoa>();

            CreateMap<Domain.Entities.UF, Services.PessoaUF>();
            CreateMap<Domain.Entities.UF, Services.UF>();

            this.Internal().ForAllMaps((typeMap, mappingExpression) =>
                mappingExpression.ForMember("Id", o => o.MapFrom(typeMap.SourceType.Name + "Id"))
            );
        }
    }
}
