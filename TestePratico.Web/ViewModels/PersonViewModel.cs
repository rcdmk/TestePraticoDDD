using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestePratico.Web.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel() : this(0, "") { }

        public PersonViewModel(int personId, string name)
        {
            this.PersonId = personId;
            this.Name = name;
        }

        [Key]
        public int PersonId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Area Code")]
        [MinLength(2)]
        [MaxLength(2)]
        [Phone]
        public string? AreaCode { get; set; }

        [MinLength(8)]
        [MaxLength(10)]
        [Phone]
        public string? Phone { get; set; }

        [MinLength(4)]
        [MaxLength(150)]
        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "State")]
        public int? UFId { get; set; }

        [Editable(false)]
        [ValidateNever]
        public virtual string? UF { get; set; }

        [Editable(false)]
        [ValidateNever]
        public virtual IList<SelectListItem>? UFs { get; set; }

        [Display(Name = "Created")]
        [Editable(false)]
        public DateTime CreatedAt { get; private set; }

        [Display(Name = "Last Update")]
        [Editable(false)]
        public DateTime UpdatedAt { get; private set; }
    }
}
