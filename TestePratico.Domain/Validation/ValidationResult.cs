namespace TestePratico.Domain.Validation
{
    public class ValidationResult
    {
        protected readonly List<ValidationError> errors;

        public IEnumerable<ValidationError> Errors
        {
            get { return errors; }
        }

        public bool IsValid
        {
            get { return errors.Count == 0; }
        }

        public ValidationResult()
        {
            errors = new List<ValidationError>();
        }

        public void Add(string field, string errorMessage)
        {
            errors.Add(new ValidationError(field, errorMessage));
        }

        public void Remove(string field, string errorMessage)
        {
            var error = errors.FirstOrDefault(e => e.Field == field && e.Message == errorMessage);

            if (error != null) errors.Remove(error);
        }

        public override string ToString()
        {
            if (IsValid) return "Valid";

            var errors = String.Join(", ", Errors.Select((e) => e.ToString()).ToArray());

            return $"Errors: {errors}";
        }
    }
}
