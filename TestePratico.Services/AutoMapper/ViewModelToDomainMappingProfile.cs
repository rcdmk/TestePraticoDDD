using AutoMapper;

namespace TestePratico.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base(nameof(ViewModelToDomainMappingProfile))
        {
            CreateMap<Services.Pessoa, Domain.Entities.Pessoa>().ForMember(p => p.PessoaId, o => o.MapFrom(p => p.Id));

            CreateMap<Services.UF, Domain.Entities.UF>().ForMember(u => u.UFId, o => o.MapFrom(u => u.Id));
            CreateMap<Services.UpdateUFRequest, Domain.Entities.UF>().ForMember(u => u.UFId, o => o.MapFrom(u => u.Id));
        }
    }
}
