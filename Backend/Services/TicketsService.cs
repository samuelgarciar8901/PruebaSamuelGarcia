using PruebaTecnicaSamuelGarcia.Data;
using PruebaTecnicaSamuelGarcia.Interfaces;
using PruebaTecnicaSamuelGarcia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace PruebaTecnicaSamuelGarcia.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly DoubleVDbContext _doubleVDbContext;
        public TicketsService(DoubleVDbContext doubleVDbContext)

        {
            _doubleVDbContext = doubleVDbContext;
        }

        public async Task<List<Ticket>> GetallTicketAsync()
        {
            return await _doubleVDbContext.Tickets.ToListAsync();

        }

        public async Task<Ticket> GetTicketbyIdAsync(int id)
        {

            return await _doubleVDbContext.Tickets.FindAsync(id);
        }

        public async Task<Ticket> AgregarTicket(Ticket request)
        {

            _doubleVDbContext.Tickets.Add(request);
            await _doubleVDbContext.SaveChangesAsync();
            return request;
        }


        public async Task<bool> ActualizarTicket(int id, Ticket request)
        {
            var ticketExistente = await _doubleVDbContext.Tickets.FindAsync(id);
            if (ticketExistente == null)
            {
                return false;
            }

            ticketExistente.Usuario = request.Usuario;
            ticketExistente.Descripcion = request.Descripcion;
            ticketExistente.FechaCreacion = request.FechaCreacion;
            ticketExistente.FechaActualizacion = DateTime.Now;
            ticketExistente.Estatus = request.Estatus;

            await _doubleVDbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> EliminarTicket(int id)
        {

            var ticketExistente = await _doubleVDbContext.Tickets.FindAsync(id);
            if (ticketExistente == null)
            {
                return false;
            }

            _doubleVDbContext.Remove(ticketExistente);
            await _doubleVDbContext.SaveChangesAsync(); 
            return true;


        }

    }
}
