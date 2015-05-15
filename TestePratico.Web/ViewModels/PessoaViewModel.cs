using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestePratico.Web.ViewModels
{
	public class PessoaViewModel
	{
		[Key]
		public int IdPessoa { get; set; }

		[Required]
		[MinLength(2)]
		[MaxLength(150)]
		public string Nome { get; set; }

		[Display(Name="Data de Nascimento")]
		public DateTime? DataNascimento { get; set; }

		[MinLength(2)]
		[MaxLength(2)]
		[DataType(DataType.PhoneNumber)]
		public string DDD { get; set; }

		[MinLength(8)]
		[MaxLength(10)]
		[DataType(DataType.PhoneNumber)]
		public string Telefone { get; set; }

		[MinLength(4)]
		[MaxLength(150)]
		[EmailAddress]
		public string Email { get; set; }

		[Display(Name="UF")]
		public int? IdUF { get; set; }

		public virtual UFViewModel UF { get; set; }
	}
}