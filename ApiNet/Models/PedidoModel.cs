
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNet.Models
{
    public class PedidoModel
    {
        [Key]
        public long IdPedido { get; set; }
        public double ValorTotal { get; set; }
        public double AhorroTotal { get; set; }
        public long  IdEstadoPedido { get; set; }
        public EstadoPedidoModel EstadoPedido { get; set; }
    }
}
