using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;

namespace TestePratico.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base(nameof(ViewModelToDomainMappingProfile))
        {
            CreateMap<PersonViewModel, Person>()
                .ForMember(m => m.UF, o => o.Ignore())
                .ForMember(m => m.CreatedAt, o => o.Ignore())
                .ForMember(m => m.UpdatedAt, o => o.Ignore())
                .ForAllMembers(m => m.DoNotAllowNull());

            CreateMap<UFViewModel, UF>()
                .ForMember(m => m.CreatedAt, o => o.Ignore())
                .ForMember(m => m.UpdatedAt, o => o.Ignore());
        }
    }
}
