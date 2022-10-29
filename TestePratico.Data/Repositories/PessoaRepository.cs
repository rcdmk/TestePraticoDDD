using TestePratico.Data.Context;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(TestePraticoContext db) : base(db)
        {
        }

        public override IEnumerable<Pessoa> GetAll()
        {
            return Db.Set<Pessoa>().OrderBy(p => p.Nome).ToList();
        }
    }
}
