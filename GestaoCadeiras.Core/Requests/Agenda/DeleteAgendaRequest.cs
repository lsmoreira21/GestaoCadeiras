using System.ComponentModel.DataAnnotations;

namespace GestaoCadeiras.Core.Requests.Agenda
{
    public class DeleteAgendaRequest : Request
    {
        [Required(ErrorMessage = "Id inválido")]
        public long Id { get; set; }
    }
}
