using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Agenda;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Agendas
{
    public class GetAllAgendassEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/", HandlerAsync)
           .WithName("Agendas: Get All")
           .WithSummary("Recupera todas as agendas")
           .WithDescription("Recupera todas as agendas")
           .WithOrder(5)
           .Produces<Response<Agenda?>>();

        private static async Task<IResult> HandlerAsync(
            IAgendaHandler handler)
        {
            var request = new GetAllAgendasRequest
            {
            };

            var result = await handler.GetAllAsysc(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
