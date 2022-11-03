using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TestePratico.Services.AutoMapper
{
    public class ListPessoaDomainToPessoaListConverter : ITypeConverter<IEnumerable<Domain.Entities.Pessoa>, Services.PessoaList>
    {
        public PessoaList Convert(IEnumerable<Domain.Entities.Pessoa> source, PessoaList destination, ResolutionContext context)
        {
            var result = new PessoaList();

            // Need to use the Add method to add values rather than assign it with an '=' sign
            foreach (var item in source)
            {
                result.Data.Add(context.Mapper.Map<Services.Pessoa>(item));
            }

            return result;
        }
    }
}
