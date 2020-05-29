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
    public class EstadosPedidoController : ControllerBase
    {
        #region Properties
        private readonly TiendaDBContext dBContext;
        #endregion Properties

        #region Constructor
        public EstadosPedidoController(TiendaDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Constructor

        #region Métodos
        [HttpGet("get/{id}")] //http://localhost:5000/estadosPedido/get/{id}
        public async Task<ActionResult<EstadoPedidoModel>> GetEstadoPedido(long id)
        {
            try
            {
                var EstadoPedido = await dBContext.estadosPedidos.FindAsync(id);
                if (EstadoPedido == null)
                {
                    return NotFound();
                }
                return Ok(EstadoPedido);
            }
            catch (Exception e)
            {
                return StatusCode(410);
            }
        }

        [HttpGet("all")] //http://localhost:5000/estadosPedido/all
        public async Task<ActionResult<List<EstadoPedidoModel>>> AllEstadosPedido()
        {
            try
            {
                return await dBContext.estadosPedidos.ToListAsync();
            }
            catch (Exception e)
            {
                return StatusCode(410);
            }            
        }

        [HttpPost("create")] //http://localhost:5000/estadosPedido/create
        public async Task<ActionResult<EstadoPedidoModel>> CreateEstadoPedido(EstadoPedidoModel estadoPedido)
        {
            try
            {
                dBContext.estadosPedidos.Add(estadoPedido);
                await dBContext.SaveChangesAsync();

                return Ok(estadoPedido);
            }
            catch (Exception e)
            {
                return StatusCode(410);
            }   
        }

        [HttpPut("update/{id}")] //http://localhost:5000/estadosPedido/update/id
        public async Task<IActionResult> UpdateEstadoPedido(long id, EstadoPedidoModel estadoPedido)
        {
            try
            {
                if (id != estadoPedido.IdEstadoPedido)
                {
                    return BadRequest();
                }
                else
                {
                    dBContext.Entry(estadoPedido).State = EntityState.Modified;
                    await dBContext.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                bool existeEstadoPedido = dBContext.estadosPedidos.Any(e => e.IdEstadoPedido == id);
                if(!existeEstadoPedido)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(410);
                }
            } 
        }

        [HttpDelete("delete/{id}")] //http://localhost:5000/estadosPedido/delete/id
        public async Task<IActionResult> DeleteEstadoPedido(long id)
        {
            try
            {
                var EstadoPedido = await dBContext.estadosPedidos.FindAsync(id);
                if (EstadoPedido == null)
                {
                    return NotFound();
                }
                dBContext.estadosPedidos.Remove(EstadoPedido);
                await dBContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(410);
            }
        }
        #endregion Métodos

    }
}