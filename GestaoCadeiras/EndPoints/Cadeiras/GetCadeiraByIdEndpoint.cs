using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Cadeira;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Cadeiras
{
    public class GetCadeiraByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandlerAsync)
               .WithName("Cadeiras: Get By Id")
               .WithSummary("Recupera uma cadeira")
               .WithDescription("Recupera uma cadeira")
               .WithOrder(4)
               .Produces<Response<Cadeira?>>();

        private static async Task<IResult> HandlerAsync(
            ICadeiraHandler handler,
            long id)
        {
            var request = new GetCadeiraByIdRequest
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
