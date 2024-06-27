using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Agenda;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Agendas
{
    public class UpdateAgendaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/{id}", HandleAsync)
                .WithName("Agenda: Update")
                .WithSummary("Atualiza uma agenda")
                .WithDescription("Atualiza uma agenda")
                .WithOrder(2)
                .Produces<Response<Agenda?>>();

        private static async Task<IResult> HandleAsync(
        IAgendaHandler handler,
            UpdateAgendaRequest request,
            long id)
        {
            request.Id = id;

            var result = await handler.UpdateAsysc(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
