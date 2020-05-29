using Microsoft.EntityFrameworkCore;

namespace ApiNet.Models
{
    public class TiendaDBContext : DbContext
    {
        public TiendaDBContext(DbContextOptions<TiendaDBContext> options)
            : base(options) { }

        public DbSet<EstadoPedidoModel> estadosPedidos { get; set; }
        public DbSet<PedidoModel> pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoModel>()
                        .HasOne(ep => ep.EstadoPedido)
                        .WithMany(p => p.Pedidos)
                        .HasForeignKey(ep => ep.IdEstadoPedido);
        }
    }
}