using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmanNayran.Models
{
    public class Produto
    {
        [Display(Name = "Código do Produto")]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        [Display(Name = "Preço")]
        public double Preco { get; set; }
        
        // Relacionamento com Marca
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        
        // Relacionamento com NotaDeVenda
        public virtual ICollection<NotaDeVenda> NotaDeVenda { get; set; }

    }
}