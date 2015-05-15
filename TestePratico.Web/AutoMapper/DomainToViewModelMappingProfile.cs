using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;

namespace TestePratico.Web.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public override string ProfileName
		{
			get
			{
				return "DomainToViewModelMappingProfile";
			}
		}


		protected override void Configure()
		{
			Mapper.CreateMap<Pessoa, PessoaViewModel>();
			Mapper.CreateMap<UF, UFViewModel>().ForMember(x => x.NumPessoas, o => o.MapFrom(x => x.Pessoas.Count()));
		}
	}
}