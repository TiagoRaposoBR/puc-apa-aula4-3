using System;

namespace Domain.Entities
{
	public class ContaCorrente : BaseEntity
	{
		private decimal _Saldo;
		public decimal Saldo
		{
			get
			{
				return _Saldo;
			}
			set
			{
				if (SaldoValido(value))
					_Saldo = value;
				else
					throw new System.InvalidOperationException("Não há limite de crédito suficiente para esta operação");
			}
		}

		private decimal _LimiteCredito;
		public decimal LimiteCredito
		{
			get
			{
				return _LimiteCredito;
			}
			set
			{
				_LimiteCredito = Math.Abs(value);
			}
		}

		public bool SaldoValido(decimal novoSaldo)
		{
			return novoSaldo >= -LimiteCredito;
		}
	}
}