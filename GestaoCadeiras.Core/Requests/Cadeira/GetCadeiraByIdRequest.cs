using System.ComponentModel.DataAnnotations;

namespace GestaoCadeiras.Core.Requests.Cadeira
{
    public class GetCadeiraByIdRequest : Request
    {
        [Required(ErrorMessage = "Id inválido")]
        public long Id { get; set; }
    }
}
