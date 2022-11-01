using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;

namespace TestePratico.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base(nameof(ViewModelToDomainMappingProfile))
        {
            CreateMap<PessoaViewModel, Pessoa>().ForMember(m => m.UF, o => o.Ignore()).ForAllMembers(m => m.DoNotAllowNull());
            CreateMap<UFViewModel, UF>();
        }
    }
}
