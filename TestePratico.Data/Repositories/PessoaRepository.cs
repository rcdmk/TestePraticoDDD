using Microsoft.EntityFrameworkCore;
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

        public override Pessoa GetById(int id)
        {
            return Db.Set<Pessoa>().Include(p => p.UF).FirstOrDefault(p => p.PessoaId == id)!;
        }

        public override IEnumerable<Pessoa> GetAll()
        {
            return Db.Set<Pessoa>().Include(p => p.UF).OrderBy(p => p.Nome).ToList();
        }
    }
}
