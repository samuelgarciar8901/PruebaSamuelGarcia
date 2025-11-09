namespace PruebaTecnicaSamuelGarcia.Models
{
    public class Ticket
    {

        public int Id { get; set; }

        public string Usuario { get; set; }
        
        public string Descripcion {  get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public bool Estatus { get; set; }


    }
}
