using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestePratico.Web.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel() : this(0, "") { }

        public PessoaViewModel(int pessoaId, string nome)
        {
            this.PessoaId = pessoaId;
            this.Nome = nome;
        }

        [Key]
        public int PessoaId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DataNascimento { get; set; }

        [MinLength(2)]
        [MaxLength(2)]
        [Phone]
        public string? DDD { get; set; }

        [MinLength(8)]
        [MaxLength(10)]
        [Phone]
        public string? Telefone { get; set; }

        [MinLength(4)]
        [MaxLength(150)]
        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Estado")]
        public int? UFId { get; set; }

        [Editable(false)]
        [ValidateNever]
        public virtual string? UF { get; set; }

        [Editable(false)]
        [ValidateNever]
        public virtual IList<SelectListItem>? UFs { get; set; }
    }
}
