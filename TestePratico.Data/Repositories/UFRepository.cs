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
            return Db.Set<UF>().OrderBy(u => u.Nome).ToList();
        }
    }
}
