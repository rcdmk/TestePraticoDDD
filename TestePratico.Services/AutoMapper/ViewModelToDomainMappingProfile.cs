using AutoMapper;
using TestePratico.Domain.Entities;

namespace TestePratico.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base(nameof(ViewModelToDomainMappingProfile))
        {
        }
    }
}
