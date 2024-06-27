using GestaoCadeiras.API.Common;
using GestaoCadeiras.API.EndPoints.Agendas;
using GestaoCadeiras.API.EndPoints.Automatico;
using GestaoCadeiras.API.EndPoints.Cadeiras;

namespace GestaoCadeiras.API.EndPoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("v1/cadeiras")
                .WithTags("Cadeiras")
                .MapEndpoint<CreateCadeiraEndpoint>()
                .MapEndpoint<UpdateCadeiraEndpoint>()
                .MapEndpoint<DeleteCadeiraEndpoint>()
                .MapEndpoint<GetCadeiraByIdEndpoint>()
                .MapEndpoint<GetAllCadeirasEndpoint>();

            endpoints.MapGroup("v1/agendas")
                .WithTags("Agendas")
                .MapEndpoint<CreateAgendaEndpoint>()
                .MapEndpoint<UpdateAgendaEndpoint>()
                .MapEndpoint<DeleteAgendaEndpoint>()
                .MapEndpoint<GetAgendaByIdEndpoint>()
                .MapEndpoint<GetAllAgendassEndpoint>();

            endpoints.MapGroup("v1/automatico")
                .WithTags("Automatico")
                .MapEndpoint<ProximoAgendamentoEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
