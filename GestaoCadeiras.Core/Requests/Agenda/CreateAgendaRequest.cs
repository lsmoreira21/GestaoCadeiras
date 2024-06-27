using System.ComponentModel.DataAnnotations;

namespace GestaoCadeiras.Core.Requests.Agenda
{
    public class CreateAgendaRequest : Request
    {
        [Required(ErrorMessage = "Cadeira inválida")]
        public int CadeiraId { get; set; }

        [Required(ErrorMessage = "Data inválida")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Hora inicial inválida")]
        public DateTime HoraInicio { get; set; }

        [Required(ErrorMessage = "Hora final inválida")]
        public DateTime HoraFim { get; set; } 
    }
}
