using TestePratico.Domain.Entities.Validation;

namespace TestePratico.Domain.Entities
{
    public class Pessoa : EntityBase<Pessoa>
    {
        public Pessoa() : this(0, "", "", "", "", null) { }

        public Pessoa(int pessoaId, string nome, string DDD, string telefone, string email, int? UFId) : base(new PessoaValidator())
        {
            this.PessoaId = pessoaId;
            this.Nome = nome;
            this.DDD = DDD;
            this.Telefone = telefone;
            this.Email = email;
            this.UFId = UFId;
        }

        public int PessoaId { get; set; }

        public string Nome { get; set; }

        public DateOnly? DataNascimento { get; set; }

        public string DDD { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public int? UFId { get; set; }

        public virtual UF? UF { get; set; }
    }
}
