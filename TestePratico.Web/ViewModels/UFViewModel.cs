using System.ComponentModel.DataAnnotations;

namespace TestePratico.Web.ViewModels
{
    public class UFViewModel
    {
        public UFViewModel() : this(0, "") { }

        public UFViewModel(int uFId, string nome)
        {
            this.UFId = uFId;
            this.Name = nome;
        }

        [Key]
        public int UFId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "People")]
        [Editable(false)]
        public int PeopleCount { get; private set; }

        [Display(Name = "Created")]
        [Editable(false)]
        public DateTime CreatedAt { get; private set; }

        [Display(Name = "Last Update")]
        [Editable(false)]
        public DateTime UpdatedAt { get; private set; }
    }
}
