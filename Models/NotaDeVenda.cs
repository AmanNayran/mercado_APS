using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmanNayran.Models
{
    public class NotaDeVenda
    {
        [Display(Name = "Código da Nota")]
        public int NotaDeVendaId { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        
        // Relacionamento com Vendedor
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        // Relacionamento com Cliente
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relacionamento com Transportadora
        public int? TransportadoraId { get; set; }
        public Transportadora Transportadora { get; set; }
        
        // Relacionamento com Produto
        public virtual ICollection<Produto> Produtos { get; set; }
        // Relacionamento com Pagamento
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }
}