using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Agenda;
using GestaoCadeiras.Core.Responses;
using Microsoft.AspNetCore.Builder;

namespace GestaoCadeiras.API.EndPoints.Automatico
{
    public class ProximoAgendamentoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Automatico: Create")
            .WithSummary("Cria uma nova Agenda automática")
            .WithDescription("Cria uma nova Agenda automática")
            .WithOrder(6)
            .Produces<Response<Agenda?>>();

        private static async Task<IResult> HandleAsync(
            IAgendaHandler handler,
            AutomaticoAgendaRequest request)
        {
            var response = await handler.AgendamentoAutomatico(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/automatico/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }
    }
}
