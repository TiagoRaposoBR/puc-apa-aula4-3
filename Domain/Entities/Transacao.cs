

using System;

namespace Domain.Entities
{
    public class Transacao
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        
        public bool PrecisaNotificarCoaf()
        {
            return Math.Abs(Valor) > 50000;
        }
    }
}