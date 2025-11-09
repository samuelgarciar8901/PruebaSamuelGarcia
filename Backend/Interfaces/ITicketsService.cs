using PruebaTecnicaSamuelGarcia.Models;

namespace PruebaTecnicaSamuelGarcia.Interfaces
{
    public interface ITicketsService
    {
       Task<List<Ticket>> GetallTicketAsync();

        Task<Ticket> GetTicketbyIdAsync(int id);

        Task<Ticket> AgregarTicket(Ticket request);

        Task<bool> ActualizarTicket(int id, Ticket request);

        Task<bool> EliminarTicket(int id);

    }
}
