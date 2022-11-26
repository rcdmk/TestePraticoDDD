using System.ComponentModel.DataAnnotations.Schema;
using TestePratico.Domain.Entities.Validation;

namespace TestePratico.Domain.Entities
{
    public class UF : EntityBase<UF>
    {
        public UF() : this(0, "") { }

        public UF(int UFId, string nome) : base(new UFValidator())
        {
            this.UFId = UFId;
            this.Nome = nome;
            this.Pessoas = new List<Person>();
            this.NumPessoas = 0;
        }

        public int UFId { get; set; }

        public string Nome { get; set; }

        [NotMapped]
        public virtual int NumPessoas { get; set; }

        public virtual IList<Person> Pessoas { get; set; }

        public UF WithNumPessoas(int numPessoas)
        {
            this.NumPessoas = numPessoas;
            return this;
        }
    }
}
