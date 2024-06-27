using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestaoCadeiras.Core.Requests.Cadeira
{
    public class UpdateCadeiraRequest : Request
    {
        [JsonIgnore]
        public long Id { get; set; }

        [Required(ErrorMessage = "Descrição inválido")]
        [MaxLength(100, ErrorMessage = "A descrição deve conter até 100 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Número inválido")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Valor inválido para o campo Ativo")]
        public bool Ativo { get; set; } = true;
    }
}
