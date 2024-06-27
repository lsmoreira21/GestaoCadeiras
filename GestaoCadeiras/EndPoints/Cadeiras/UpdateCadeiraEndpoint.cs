using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Cadeira;
using GestaoCadeiras.Core.Responses;


namespace GestaoCadeiras.API.EndPoints.Cadeiras
{
    public class UpdateCadeiraEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/{id}", HandleAsync)
                .WithName("Cadeiras: Update")
                .WithSummary("Atualiza uma cadeira")
                .WithDescription("Atualiza uma cadeira")
                .WithOrder(2)
                .Produces<Response<Cadeira?>>();

        private static async Task<IResult> HandleAsync(
        ICadeiraHandler handler,
            UpdateCadeiraRequest request,
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
