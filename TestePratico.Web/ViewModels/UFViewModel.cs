using System.ComponentModel.DataAnnotations;

namespace TestePratico.Web.ViewModels
{
    public class UFViewModel
    {
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
