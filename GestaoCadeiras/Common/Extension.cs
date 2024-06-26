using GestaoCadeiras.API.Data;
using GestaoCadeiras.API.Handlers;
using GestaoCadeiras.Core.Handlers;
using Microsoft.EntityFrameworkCore;

namespace GestaoCadeiras.API.Common
{
    public static class Extension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder
                .Services
            .AddDbContext<AppDbContext>(x =>
            {
                    x.UseMySql(Configuration.ConnectionString, ServerVersion.AutoDetect(Configuration.ConnectionString));
                });
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddTransient<ICadeiraHandler, CadeiraHandler>();

            //builder
            //    .Services
            //    .AddTransient<IAgendaHandler, AgendaHandler>();
        }
    }
}
