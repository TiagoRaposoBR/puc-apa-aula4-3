using System;

namespace Domain.Entities
{
	public class Correntista : BaseEntity
	{
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public ContaCorrente Conta { get; set; }
	}
}