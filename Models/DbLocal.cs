using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Patrimonio.Models
{
    [Table("local", Schema = "public")]
    public class DbLocal
    {
        [Key]
        public int idlocal { get; set; }
        public string nomelocal { get; set; }
	    public string descricaolocal { get; set; }
    }
}
