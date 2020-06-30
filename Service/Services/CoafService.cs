

using System;
using System.Text;
using Domain.Entities;

namespace Service.Services
{
    public class CoafService
    {
        public void NotificarCoafApi(Correntista correntista, Transacao transacao)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Movimentação acima dos limites, notificando Coaf");
            builder.Append("\nNome: ");
            builder.Append(correntista.Nome);
            builder.Append("\nCPF: ");
            builder.Append(correntista.Cpf);
            builder.Append("\nValor: R$ ");
            builder.Append(transacao.Valor);
            builder.Append("\nData: ");
            builder.Append(DateTime.Now.ToString("dd/mm/yyyy HH:mm"));

            Console.WriteLine(builder.ToString());
        }
    }
}