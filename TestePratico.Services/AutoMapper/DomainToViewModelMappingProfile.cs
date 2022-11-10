using AutoMapper;

namespace TestePratico.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base(nameof(DomainToViewModelMappingProfile))
        {
            CreateMap<Domain.Entities.Pessoa, Services.Pessoa>().ForMember(p => p.Id, o => o.MapFrom(p => p.PessoaId));

            CreateMap<Domain.Entities.UF, Services.PessoaUF>().ForMember(u => u.Id, o => o.MapFrom(u => u.UFId));
            CreateMap<Domain.Entities.UF, Services.UF>().ForMember(u => u.Id, o => o.MapFrom(u => u.UFId));
        }
    }
}
