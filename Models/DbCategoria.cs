using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Patrimonio.Models
{
    [Table("categoria", Schema = "public")]
    public class DbCategoria
    {
        [Key]
       public int idcategoria { get; set; }
        public string descricaocategoria { get; set; }
    }
}
