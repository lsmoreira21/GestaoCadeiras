using GestaoCadeiras.API.Common;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Cadeira;
using GestaoCadeiras.Core.Responses;

namespace GestaoCadeiras.API.EndPoints.Cadeiras
{
    public class CreateCadeiraEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Cadeiras: Create")
            .WithSummary("Cria uma nova cadeira")
            .WithDescription("Cria uma nova cadeira")
            .WithOrder(1)
            .Produces<Response<Cadeira?>>();

        private static async Task<IResult> HandleAsync(
            ICadeiraHandler handler,
            CreateCadeiraRequest request)

        {
                var response = await handler.CreateAsysc(request);

                return response.IsSuccess
                    ? TypedResults.Created($"v1/cadeira/{response.Data?.Id}", response)
                    : TypedResults.BadRequest(response);                

        }
    }
}
