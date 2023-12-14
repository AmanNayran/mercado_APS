using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmanNayran.Models
{
    public class Pagamento
    {
        [Display(Name = "Código do Pagamento")]
        public int PagamentoId { get; set; }
        public double Valor { get; set; }
        public bool Pago { get; set; }

        // Relacionamento com NotaDeVenda
        public int NotaDeVendaId { get; set; }
        public NotaDeVenda NotaDeVenda { get; set; }

        // Relacionamento com TipoDePagamento
        public int TipoDePagamentoId { get; set; }
        public TipoDePagamento TipoDePagamento { get; set; }

    }
}