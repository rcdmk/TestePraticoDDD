using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TestePratico.Services.AutoMapper
{
    public class ListDomainToGrpcResponseConverter<TEntitya, TResponse, T> : ITypeConverter<IEnumerable<TEntitya>, TResponse> where TResponse : ICollection<T>
    {
        public TResponse Convert(IEnumerable<TEntitya> source, TResponse destination, ResolutionContext context)
        {
            // Need to use the Add method to add values rather than assign it with an '=' sign
            foreach (var item in source)
            {
                destination.Add(context.Mapper.Map<T>(item));
            }

            return destination;
        }
    }
}
