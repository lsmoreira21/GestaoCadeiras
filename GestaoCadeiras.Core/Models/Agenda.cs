
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestaoCadeiras.Core.Models
{
    public class Agenda 
    {
        public Agenda(int agendaId, int cadeiraId, DateTime data, TimeOnly horaInicio, TimeOnly horaFim)
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

        public DateTime Data { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFim { get; set; }

        [JsonIgnore]
        public virtual Cadeira? Cadeira { get; set; }
    }
}

