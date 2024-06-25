
using System.ComponentModel.DataAnnotations;

namespace GestaoCadeiras.Core.Models
{
    public class Agenda 
    {
        public Agenda(Guid agendaId, Guid cadeiraId, DateOnly data, TimeOnly horaInicio, TimeOnly horaFim)
        {
            Id = agendaId;
            CadeiraId = cadeiraId;
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }

        protected Agenda() { }
        [Key]
        public Guid Id { get; set; }

        public Guid CadeiraId { get; set; }

        public DateOnly Data { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFim { get; set; }

        public virtual Cadeira? Cadeira { get; set; }
    }
}

