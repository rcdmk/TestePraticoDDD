﻿using AutoMapper;
using AutoMapper.Internal;

namespace TestePratico.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base(nameof(ViewModelToDomainMappingProfile))
        {
            CreateMap<Services.Pessoa, Domain.Entities.Pessoa>();
            CreateMap<Services.CreatePessoaRequest, Domain.Entities.Pessoa>();
            CreateMap<Services.UpdatePessoaRequest, Domain.Entities.Pessoa>();


            CreateMap<Services.UF, Domain.Entities.UF>();
            CreateMap<Services.UpdateUFRequest, Domain.Entities.UF>();

            this.Internal().ForAllMaps((typeMap, mappingExpression) =>
            {
                if (typeMap.Types.SourceType != typeof(Services.CreatePessoaRequest))
                    mappingExpression.ForMember(typeMap.DestinationType.Name + "Id", o => o.MapFrom("Id"));
            }
            );
        }
    }
}
