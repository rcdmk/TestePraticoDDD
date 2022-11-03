using System.ComponentModel.DataAnnotations;

namespace TestePratico.Web.ViewModels
{
    public class UFViewModel
    {
        public UFViewModel() : this(0, "") { }

        public UFViewModel(int uFId, string nome)
        {
            this.UFId = uFId;
            this.Nome = nome;
        }

        [Key]
        public int UFId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Pessoas")]
        [Editable(false)]
        public int NumPessoas { get; private set; }
    }
}
