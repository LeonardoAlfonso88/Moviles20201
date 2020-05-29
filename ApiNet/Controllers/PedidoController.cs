using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ApiNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        #region Properties
        private readonly TiendaDBContext dBContext;
        #endregion Properties

        #region Constructor
        public PedidoController(TiendaDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Constructor

        #region Métodos
        [HttpGet("get/{id}")] //http://localhost:5000/pedido/get/{id}
        public async Task<ActionResult<EstadoPedidoModel>> GetEstadoPedido(long id)
        {
            try
            {
                var Pedido = await dBContext.pedidos
                                            .Include(es => es.EstadoPedido)
                                            .FirstAsync(p => p.IdPedido == id);
                if (Pedido == null)
                {
                    return NotFound();
                }
                return Ok(Pedido);
            }
            catch (Exception e)
            {
                return StatusCode(410);
            }
        }

        [HttpPost("create")] //http://localhost:5000/pedido/create
        public async Task<ActionResult<EstadoPedidoModel>> CreateEstadoPedido(PedidoModel pedido)
        {
            try
            {
                dBContext.pedidos.Add(pedido);
                await dBContext.SaveChangesAsync();
                return Ok(pedido);
            }
            catch (Exception e)
            {
                return StatusCode(410);
            }   
        }
        #endregion Métodos

    }
}