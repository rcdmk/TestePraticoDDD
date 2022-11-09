using TestePratico.Data.Context;
using TestePratico.Domain.Entities;
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
            return Db.Set<UF>().Select(u => new UF
            {
                UFId = u.UFId,
                Nome = u.Nome,
                NumPessoas = u.Pessoas.Count()
            }).OrderBy(u => u.Nome).ToList();
        }

        public override UF GetById(int id)
        {
            return Db.Set<UF>().Select(u => new UF
            {
                UFId = u.UFId,
                Nome = u.Nome,
                NumPessoas = u.Pessoas.Count()
            }).FirstOrDefault(u => u.UFId == id)!;
        }
    }
}
