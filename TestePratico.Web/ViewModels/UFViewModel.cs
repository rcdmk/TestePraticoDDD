using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestePratico.Web.ViewModels
{
	public class UFViewModel
	{
		[Key]
		public int IdUF { get; set; }

		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		public string Nome { get; set; }

		[Display(Name="Pessoas")]
		[Editable(false)]
		public int NumPessoas { get; private set; }
	}
}