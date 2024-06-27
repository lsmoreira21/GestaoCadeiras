using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCadeiras.Core.Requests.Agenda
{
    public class AutomaticoAgendaRequest : Request
    {

        [Required(ErrorMessage = "Data inválida")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Hora inicial inválida")]
        public DateTime HoraInicio { get; set; }

        [Required(ErrorMessage = "Hora final inválida")]
        public DateTime HoraFim { get; set; }
    }
}
