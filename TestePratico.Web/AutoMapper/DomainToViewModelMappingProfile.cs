using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;

namespace TestePratico.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base(nameof(DomainToViewModelMappingProfile))
        {
            CreateMap<Person, PessoaViewModel>().ForMember(p => p.UF, m => m.MapFrom(p => p.UF != null ? p.UF.Name : ""));
            CreateMap<UF, UFViewModel>();

            CreateMap<UF, SelectListItem>()
                .ForMember(x => x.Value, o => o.MapFrom(x => x.UFId))
                .ForMember(x => x.Text, o => o.MapFrom(x => x.Name));
        }
    }
}
