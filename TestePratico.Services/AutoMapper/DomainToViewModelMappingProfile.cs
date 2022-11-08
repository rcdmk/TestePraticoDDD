using AutoMapper;
using Google.Protobuf.Collections;
using TestePratico.Domain.Entities;

namespace TestePratico.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base(nameof(DomainToViewModelMappingProfile))
        {
            CreateMap<Domain.Entities.Pessoa, Services.Pessoa>();
            CreateMap<IEnumerable<Domain.Entities.Pessoa>, RepeatedField<Services.Pessoa>>()
                .ConvertUsing<ListDomainToGrpcResponseConverter<Domain.Entities.Pessoa, RepeatedField<Services.Pessoa>, Services.Pessoa>>();

            CreateMap<Domain.Entities.UF, Services.PessoaUF>().ForMember(u => u.Id, o => o.MapFrom(u => u.UFId));

            CreateMap<Domain.Entities.UF, Services.UF>();
            CreateMap<IEnumerable<Domain.Entities.UF>, RepeatedField<Services.UF>>()
                .ConvertUsing<ListDomainToGrpcResponseConverter<Domain.Entities.UF, RepeatedField<Services.UF>, Services.UF>>();
        }
    }
}
