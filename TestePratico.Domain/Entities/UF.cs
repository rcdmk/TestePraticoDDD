using TestePratico.Domain.Entities.Validation;
using TestePratico.Domain.Interfaces.Validation;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities
{
    public class UF : IValidable
    {
        public int UFId { get; set; }
        public string Nome { get; set; }

        public virtual List<Pessoa> Pessoas { get; set; }

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
