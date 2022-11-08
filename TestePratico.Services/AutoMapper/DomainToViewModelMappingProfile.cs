using AutoMapper;
using TestePratico.Domain.Entities;

namespace TestePratico.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base(nameof(DomainToViewModelMappingProfile))
        {
            CreateMap<Domain.Entities.Pessoa, Services.Pessoa>().ForMember(p => p.Uf, o => o.MapFrom(p => p.UF.Nome));
            CreateMap<IEnumerable<Domain.Entities.Pessoa>, PessoaList>().ConvertUsing<ListPessoaDomainToPessoaListConverter>();

            CreateMap<Domain.Entities.UF, Services.UF>();
            CreateMap<IEnumerable<Domain.Entities.UF>, GetAllResponse>().ConvertUsing<ListUFDomainToUFListConverter>();
        }
    }
}
