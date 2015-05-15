using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;

namespace TestePratico.Web.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public override string ProfileName
		{
			get
			{
				return "ViewModelToDomainMappingProfile";
			}
		}


		protected override void Configure()
		{
			Mapper.CreateMap<PessoaViewModel, Pessoa>();
			Mapper.CreateMap<UFViewModel, UF>();
		}
	}
}