namespace Sistema_Patrimonio.Models
{
    public class DtoPatrimonio
    {
		public int idpatrimonio { get; set; }
		public string numetiqueta { get; set; }
		public string nomepatrimonio { get; set; }
		public string descricaopatrimonio { get; set; }
		public decimal valorpatrimonio { get; set; }
		public string descricaocategoria { get; set; }
		public string nomedepartamento { get; set; }
		public string nomelocal { get; set; }
		public string marcamodelo { get; set; }
		public DateTime dataaquisicao { get; set; }
		public DateTime databaixa { get; set; }
		public int numnf { get; set; }
		public string numserie { get; set; }
		public string situacao { get; set; }
		public string nomefornecedor { get; set; }
		public DateTime datagarantia { get; set; }
	}
}
