using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiNet.Models
{
    public class EstadoPedidoModel
    {
        [Key]
        public long IdEstadoPedido { get; set; }
        public string Estado { get; set; }
        public List<PedidoModel> Pedidos { get; set; }
    }
}
