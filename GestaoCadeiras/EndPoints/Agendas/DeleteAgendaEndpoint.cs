using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Agenda;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Agendas
{
    public class DeleteAgendaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandlerAsync)
            .WithName("Agendas: Delete")
            .WithSummary("Excluir uma agenda")
            .WithDescription("Excluir uma agenda")
            .WithOrder(3)
            .Produces<Response<Agenda?>>();

        private static async Task<IResult> HandlerAsync(
            IAgendaHandler handler,
            long id)
        {
            var request = new DeleteAgendaRequest
            {
                Id = id
            };

            var result = await handler.DeleteAsysc(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }

}
