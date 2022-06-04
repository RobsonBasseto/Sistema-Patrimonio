using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Patrimonio.Models
{
    [Table("fornecedor", Schema = "public")]
    public class DbFornecedor
    {
        [Key]
        public int idfornecedor { get; set; }
        public string nomefornecedor { get; set; }
	    public string endereco { get; set; }
	    public string fone { get; set; }
    }
}
