using Microsoft.EntityFrameworkCore;
using TestePratico.Data.Context;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Person>, IPessoaRepository
    {
        public PessoaRepository(TestePraticoContext db) : base(db)
        {
        }

        public override Person GetById(int id)
        {
            return Db.Set<Person>()
                .Include(p => p.UF)
                .FirstOrDefault(p => p.PersonId == id)!;
        }

        public override IEnumerable<Person> GetAll()
        {
            return Db.Set<Person>()
                .Include(p => p.UF)
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
