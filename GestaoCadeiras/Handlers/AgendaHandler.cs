using GestaoCadeiras.API.Data;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Agenda;
using GestaoCadeiras.Core.Requests.Cadeira;
using GestaoCadeiras.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Globalization;

namespace GestaoCadeiras.API.Handlers
{
    public class AgendaHandler(AppDbContext context) : IAgendaHandler
    {
        async Task<Response<Agenda?>> IAgendaHandler.CreateAsysc(CreateAgendaRequest request)
        {
            try
            {
                var agenda = new Agenda
                {
                    CadeiraId = request.CadeiraId,
                    Data = request.Data,
                    HoraInicio = TimeOnly.FromDateTime(request.HoraInicio),
                    HoraFim = TimeOnly.FromDateTime(request.HoraFim)
                };

                context.Agendas.Add(agenda);
                await context.SaveChangesAsync();

                return new Response<Agenda?>(agenda, 201, "Agenda criada com sucesso");
            }
            catch (Exception e)
            {
                return new Response<Agenda?>(null, 500, "Não foi possível criar a agenda");
            }
        }

        async Task<Response<Agenda?>> IAgendaHandler.DeleteAsysc(DeleteAgendaRequest request)
        {
            try
            {
                var agenda = await context
                    .Agendas
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (agenda is null)
                    return new Response<Agenda?>(null, 404, "Agenda não encontrada");

                context.Agendas.Remove(agenda);
                await context.SaveChangesAsync();

                return new Response<Agenda?>(agenda, 200, "Agenda excluída com sucesso");
            }
            catch (Exception e)
            {
                return new Response<Agenda?>(null, 500, "Não foi possível excluir a agenda");
            }
        }

        async Task<Response<List<Agenda>>> IAgendaHandler.GetAllAsysc(GetAllAgendasRequest request)
        {
            var query = context
                .Agendas
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .OrderBy(x => x.HoraInicio);

            var agendas = await query
                .ToListAsync();

            return agendas is null
                ? new Response<List<Agenda>>(null, 404, "Não existe agenda cadastrada")
                : new Response<List<Agenda>>(agendas, 200, "Consulta realizada com sucesso");
        }

        async Task<Response<Agenda?>> IAgendaHandler.GetByIdAsysc(GetAgendaByIdRequest request)
        {
            try
            {
                var agenda = await context
                    .Agendas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return agenda is null
                    ? new Response<Agenda?>(null, 404, "Agenda não encontrada")
                    : new Response<Agenda?>(agenda, 200, "Consulta realizada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Agenda?>(null, 500, "Não foi possível buscar a agenda");
            }
        }

        async Task<Response<Agenda?>> IAgendaHandler.UpdateAsysc(UpdateAgendaRequest request)
        {
            try
            {
                var agenda = await context
                    .Agendas
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (agenda is null)
                    return new Response<Agenda?>(null, 404, "Agenda não encontrada");

                agenda.CadeiraId = request.CadeiraId;
                agenda.Data = request.Data;
                agenda.HoraInicio = TimeOnly.FromDateTime(request.HoraInicio);
                agenda.HoraFim = TimeOnly.FromDateTime(request.HoraFim);

                context.Agendas.Update(agenda);
                await context.SaveChangesAsync();

                return new Response<Agenda?>(agenda, 200, "Agenda atualizada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Agenda?>(null, 500, "Não foi possível alterar a agenda");
            }
        }

        async Task<Response<Agenda?>> IAgendaHandler.AgendamentoAutomatico(AutomaticoAgendaRequest request)
        {
            try
            {
                var proximo = context.ProximoAgendamento.ToList();

                var agenda = new Agenda
                {
                    CadeiraId = proximo[0].CadeiraId,
                    Data = request.Data,
                    HoraInicio = TimeOnly.FromDateTime(request.HoraInicio),
                    HoraFim = TimeOnly.FromDateTime(request.HoraFim)
                };

                context.Agendas.Add(agenda);
                await context.SaveChangesAsync();

                return new Response<Agenda?>(agenda, 201, "Agenda criada com sucesso");

            }
            catch (Exception e)
            {
                return new Response<Agenda?>(null, 500, "Não foi possível criar a agenda");
            }

        }
    }
}