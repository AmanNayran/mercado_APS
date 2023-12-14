using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmanNayran.Models
{
    public class Marca
    {
        [Display(Name = "Código da Marca")]
        public int MarcaId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}