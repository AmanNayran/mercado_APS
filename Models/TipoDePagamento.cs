using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmanNayran.Models
{
    public class TipoDePagamento
    {
        [Display(Name = "Código do Tipo de pagamento")]
        public int TipoDePagamentoId { get; set; }
        [Display(Name = "Forma de pagamento")]
        public string FormaDePagamento { get; set; }
        [Display(Name = "Informações adicionais")]
        public string InformacoesAdicionais { get; set; }
        
        // Relacionamento com Pagamento
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }
}