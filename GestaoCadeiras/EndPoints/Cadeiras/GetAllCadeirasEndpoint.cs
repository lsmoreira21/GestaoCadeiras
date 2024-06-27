using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Cadeira;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Cadeiras
{
    public class GetAllCadeirasEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/", HandlerAsync)
           .WithName("Cadeiras: Get All")
           .WithSummary("Recupera todas as cadeiras")
           .WithDescription("Recupera todas as cadeiras")
           .WithOrder(5)
           .Produces<Response<Cadeira?>>();

        private static async Task<IResult> HandlerAsync(
            ICadeiraHandler handler)
        {
            var request = new GetAllCadeirasRequest
            {
            };

            var result = await handler.GetAllAsysc(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
