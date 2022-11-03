using System.ComponentModel.DataAnnotations.Schema;
using TestePratico.Domain.Entities.Validation;
using TestePratico.Domain.Interfaces.Validation;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities
{
    public class UF : IValidable
    {
        public UF() : this(0, "", new List<Pessoa>(), new ValidationResult())
        {
        }

        public UF(int ufId, string nome, IList<Pessoa> Pessoas, ValidationResult validationResult)
        {
            this.UFId = ufId;
            this.Nome = nome;
            this.NumPessoas = Pessoas.Count;
            this.Pessoas = Pessoas;
            this.ValidationResult = validationResult;
        }

        public int UFId { get; set; }

        public string Nome { get; set; }

        [NotMapped]
        public virtual int NumPessoas { get; set; }

        public virtual IList<Pessoa> Pessoas { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                ValidationResult = new UFValidator().Validate(this);

                return ValidationResult.IsValid;
            }
        }
    }
}
