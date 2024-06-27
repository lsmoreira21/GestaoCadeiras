using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Agenda;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Agendas
{
    public class CreateAgendaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Agendas: Create")
            .WithSummary("Cria uma nova Agenda")
            .WithDescription("Cria uma nova Agenda")
            .WithOrder(1)
            .Produces<Response<Agenda?>>();

        private static async Task<IResult> HandleAsync(
            IAgendaHandler handler,
            CreateAgendaRequest request)
        {
            var response = await handler.CreateAsysc(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/agenda/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }
    }
}
