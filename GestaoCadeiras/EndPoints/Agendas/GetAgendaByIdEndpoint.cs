using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Agenda;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Agendas
{
    public class GetAgendaByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandlerAsync)
               .WithName("Agendas: Get By Id")
               .WithSummary("Recupera uma agenda")
               .WithDescription("Recupera uma agenda")
               .WithOrder(4)
               .Produces<Response<Agenda?>>();

        private static async Task<IResult> HandlerAsync(
            IAgendaHandler handler,
            long id)
        {
            var request = new GetAgendaByIdRequest
            {
                Id = id
            };

            var result = await handler.GetByIdAsysc(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
