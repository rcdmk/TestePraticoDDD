using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TestePratico.Services.AutoMapper
{
    public class ListUFDomainToGetAllUFsResponseConverter : ITypeConverter<IEnumerable<Domain.Entities.UF>, Services.GetAllUFsResponse>
    {
        public GetAllUFsResponse Convert(IEnumerable<Domain.Entities.UF> source, GetAllUFsResponse destination, ResolutionContext context)
        {
            var result = new GetAllUFsResponse();

            // Need to use the Add method to add values rather than assign it with an '=' sign
            foreach (var item in source)
            {
                result.Data.Add(context.Mapper.Map<Services.UF>(item));
            }

            return result;
        }
    }
}
