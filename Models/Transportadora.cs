using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmanNayran.Models
{
    public class Transportadora
    {
        [Display(Name = "Código da Transportadora")]
        public int TransportadoraId { get; set; }
        public string Nome { get; set; }

        // Relacionamento com NotaDeVenda
        public virtual ICollection<NotaDeVenda> NotasDeVenda  { get; set; }
    }
}