using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Cadeira;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.Core.Handlers
{
    public interface ICadeiraHandler
    {
        Task<Response<Cadeira?>> CreateAsysc(CreateCadeiraRequest request);
        Task<Response<Cadeira?>> UpdateAsysc(UpdateCadeiraRequest request);
        Task<Response<Cadeira?>> DeleteAsysc(DeleteCadeiraRequest request);
        Task<Response<Cadeira?>> GetByIdAsysc(GetCadeiraByIdRequest request);
        Task<Response<List<Cadeira?>>> GetAllAsysc(GetAllCadeirasRequest request);
    }
}
