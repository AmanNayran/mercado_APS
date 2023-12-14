using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AmanNayran.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<NotaDeVenda> NotasDeVenda { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<TipoDePagamento> TiposDePagamento { get; set; }
    }
}