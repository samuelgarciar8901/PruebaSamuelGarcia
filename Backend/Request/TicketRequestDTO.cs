namespace PruebaTecnicaSamuelGarcia.Request
{
    public class TicketRequestDTO
    {

        public string Usuario { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public bool Estatus { get; set; }

    }
}
