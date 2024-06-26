
using System.ComponentModel.DataAnnotations;

namespace GestaoCadeiras.Core.Models
{
    public class Agenda 
    {
        public Agenda(int agendaId, int cadeiraId, DateOnly data, TimeOnly horaInicio, TimeOnly horaFim)
        {
            Id = agendaId;
            CadeiraId = cadeiraId;
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }

        public Agenda() { }
        [Key]
        public int Id { get; set; }

        public int CadeiraId { get; set; }

        public DateOnly Data { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFim { get; set; }

        public virtual Cadeira? Cadeira { get; set; }
    }
}

