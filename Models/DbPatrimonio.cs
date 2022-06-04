using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Patrimonio.Models
{
	[Table("patrimonio", Schema = "public")]
	public class DbPatrimonio
    {
		[Key]
		public int idpatrimonio {get; set;}
		public string numetiqueta {get; set;}
		public string nomepatrimonio {get; set;}
		public string descricaopatrimonio {get; set;}
		public decimal valorpatrimonio {get; set;}
		public int idcategoria {get; set;}
		public int iddepartamento {get; set;}
		public int idlocal {get; set;}
		public string marcamodelo {get; set;}
		public DateTime dataaquisicao {get; set;}
		public DateTime databaixa {get; set;}
		public int numnf {get; set;}
		public string numserie {get; set;}
		public string situacao {get; set;}
		public int idfornecedor {get; set;}
		public DateTime datagarantia { get; set; }

	}
}
