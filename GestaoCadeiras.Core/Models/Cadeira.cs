using System.ComponentModel.DataAnnotations;

namespace GestaoCadeiras.Core.Models
{
    public class Cadeira 
    {
        public Cadeira(Guid cadeiraId, int numero, string descricao, bool ativo)
        {
            Id = cadeiraId;
            Numero = numero;
            Descricao = descricao;
            Ativo = ativo;
        }

        protected Cadeira() { }

        [Key]
        public Guid Id { get; set; }

        public int Numero { get; set; }

        public string Descricao { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public virtual Agenda? Agenda { get; set; }
    }
}
