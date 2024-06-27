using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Agenda;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.Core.Handlers
{
    public interface IAgendaHandler
    {
        Task<Response<Agenda?>> CreateAsysc(CreateAgendaRequest request);
        Task<Response<Agenda?>> UpdateAsysc(UpdateAgendaRequest request);
        Task<Response<Agenda?>> DeleteAsysc(DeleteAgendaRequest request);
        Task<Response<Agenda?>> GetByIdAsysc(GetAgendaByIdRequest request);
        Task<Response<List<Agenda>>> GetAllAsysc(GetAllAgendasRequest request);
        Task<Response<Agenda?>> AgendamentoAutomatico(AutomaticoAgendaRequest request);
    }
}
