﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Patrimonio.Models
{
    [Table("usuario", Schema="public")]
    public class DbUsuario
    {
        [Key]
        public int idusuario { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public char status { get; set; }
    }
}
