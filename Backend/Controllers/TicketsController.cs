using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSamuelGarcia.Interfaces;
using PruebaTecnicaSamuelGarcia.Models;
using PruebaTecnicaSamuelGarcia.Request;
using System.Runtime.InteropServices;

namespace PruebaTecnicaSamuelGarcia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;
        public TicketsController(ITicketsService ticketsService)

        {
            _ticketsService = ticketsService;
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerTickets()
        {
            var tickets = await _ticketsService.GetallTicketAsync();

            return Ok(tickets);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> ObtenerTicketById(int id)
        {

            var ticket = await _ticketsService.GetTicketbyIdAsync(id);

            return Ok(ticket);
        }


        [HttpPost("AgregarTicket")]

        public async Task<ActionResult> AgregarTicket([FromBody] TicketRequestDTO request)
        {
            try
            {
                var ticket = new Ticket();
                {
                    ticket.Usuario = request.Usuario;
                    ticket.Descripcion = request.Descripcion;
                    ticket.FechaCreacion = DateTime.Now;
                    ticket.FechaActualizacion = null;
                    ticket.Estatus = request.Estatus;

                    var created = await _ticketsService.AgregarTicket(ticket);
                    return Ok(created);
                }


            }
            catch (Exception)
            {

                throw;
            }


        }

        [HttpPut("ActualizarTicket/{id:int}")]
        public async Task<ActionResult> ActualizarTicket(int id, [FromBody] TicketRequestDTO request)
        {
            var existente = await _ticketsService.GetTicketbyIdAsync(id);
            if(existente == null)
            {
                return NotFound();
            }
            else
            {
                existente.Usuario = request.Usuario;
                existente.Descripcion = request.Descripcion;
                existente.FechaCreacion= request.FechaCreacion;
                existente.FechaActualizacion = DateTime.Now;
                existente.Estatus = request.Estatus;


                var actualizado = await _ticketsService.ActualizarTicket(id, existente);
                return Ok(actualizado);

            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult>EliminarJuguete(int id)
        {

            var eliminado = await _ticketsService.EliminarTicket(id);
            return Ok(eliminado);

        }

    }
}
