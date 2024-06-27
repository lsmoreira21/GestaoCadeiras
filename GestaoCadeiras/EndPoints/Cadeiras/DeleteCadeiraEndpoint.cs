using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Cadeira;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Cadeiras
{
    public class DeleteCadeiraEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandlerAsync)
            .WithName("Cadeiras: Delete")
            .WithSummary("Excluir uma cadeira")
            .WithDescription("Excluir uma cadeira")
            .WithOrder(3)
            .Produces<Response<Cadeira?>>();

        private static async Task<IResult> HandlerAsync(
            ICadeiraHandler handler,
            long id)
        {
            var request = new DeleteCadeiraRequest
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
