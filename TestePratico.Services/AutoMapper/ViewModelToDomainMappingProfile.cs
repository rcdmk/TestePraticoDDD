using AutoMapper;
using AutoMapper.Internal;

namespace TestePratico.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base(nameof(ViewModelToDomainMappingProfile))
        {
            CreateMap<Services.Pessoa, Domain.Entities.Person>();
            CreateMap<Services.CreatePessoaRequest, Domain.Entities.Person>();
            CreateMap<Services.UpdatePessoaRequest, Domain.Entities.Person>();


            CreateMap<Services.UF, Domain.Entities.UF>();
            CreateMap<Services.CreateUFRequest, Domain.Entities.UF>();
            CreateMap<Services.UpdateUFRequest, Domain.Entities.UF>();

            this.Internal().ForAllMaps((typeMap, mappingExpression) =>
            {
                if (typeMap.Types.SourceType.IsAssignableTo(typeof(Domain.Entities.EntityBase<>)))
                {
                    mappingExpression.ForMember(typeMap.DestinationType.Name + "Id", o => o.MapFrom("Id"));
                }
            }
            );
        }
    }
}
