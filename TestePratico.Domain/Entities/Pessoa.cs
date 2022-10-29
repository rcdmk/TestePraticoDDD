using TestePratico.Domain.Entities.Validation;
using TestePratico.Domain.Interfaces.Validation;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities
{
    public class Pessoa : IValidable
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public int? UFId { get; set; }

        public virtual UF UF { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                ValidationResult = new PessoaValidator().Validate(this);

                return ValidationResult.IsValid;
            }
        }
    }
}
