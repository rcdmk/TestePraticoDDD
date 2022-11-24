using Microsoft.EntityFrameworkCore;
using TestePratico.Data.Context;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Entities.Validation;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Data.Repositories
{
    public class UFRepository : RepositoryBase<UF>, IUFRepository
    {
        public UFRepository(TestePraticoContext db) : base(db)
        {
        }

        public override IEnumerable<UF> GetAll()
        {
            return Db.Set<UF>()
                .OrderBy(u => u.Nome)
                .Select(u => u.WithNumPessoas(u.Pessoas.Count()))
                .ToList();
        }

        public override UF GetById(int id)
        {
            return Db.Set<UF>()
                .Where(u => u.UFId == id)
                .Select(u => u.WithNumPessoas(u.Pessoas.Count()))
                .FirstOrDefault()!;
        }
    }
}
