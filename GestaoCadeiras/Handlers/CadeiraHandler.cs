using GestaoCadeiras.API.Data;
using GestaoCadeiras.Core.Handlers;
using GestaoCadeiras.Core.Models;
using GestaoCadeiras.Core.Requests.Cadeira;
using GestaoCadeiras.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace GestaoCadeiras.API.Handlers
{
    public class CadeiraHandler(AppDbContext context) : ICadeiraHandler
    {
        async Task<Response<Cadeira?>> ICadeiraHandler.CreateAsysc(CreateCadeiraRequest request)
        {
            try
            {
                var cadeira = new Cadeira
                {
                    Descricao = request.Descricao,
                    Numero = request.Numero,
                    Ativo = request.Ativo
                };

                context.Cadeiras.Add(cadeira);
                await context.SaveChangesAsync();

                return new Response<Cadeira?>(cadeira,201, "Cadeira criada com sucesso");
            }
            catch (Exception e)
            {
                return new Response<Cadeira?>(null,500, "Não foi possível criar a cadeira");
            }
        }

        async Task<Response<Cadeira?>> ICadeiraHandler.DeleteAsysc(DeleteCadeiraRequest request)
        {
            try
            {
                var cadeira = await context
                    .Cadeiras
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (cadeira is null)
                    return new Response<Cadeira?>(null,404, "Cadeira não encontrada");

                context.Cadeiras.Remove(cadeira);
                await context.SaveChangesAsync();

                return new Response<Cadeira?>(cadeira,200, "Cadeira excluída com sucesso");
            }
            catch (Exception e)
            {
                return new Response<Cadeira?>(null,500, "Não foi possível excluir a cadeira");
            }
        }

        async Task<Response<List<Cadeira>>> ICadeiraHandler.GetAllAsysc(GetAllCadeirasRequest request)
        {
            var query = context
                .Cadeiras
                .AsNoTracking()
                .OrderBy(x => x.Numero);

            var cadeiras = await query
                .ToListAsync();             

            return cadeiras is null
                ? new Response<List<Cadeira>>(null,404, "Não existe cadeira cadastrada")
                : new Response<List<Cadeira>>(cadeiras, 200, "Consulta realizada com sucesso");
        }

        async Task<Response<Cadeira?>> ICadeiraHandler.GetByIdAsysc(GetCadeiraByIdRequest request)
        {
            try
            {
                var cadeira = await context
                    .Cadeiras
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return cadeira is null
                    ? new Response<Cadeira?>(null, 404, "Cadeira não encontrada")
                    : new Response<Cadeira?>(cadeira, 200, "Consulta realizada com sucesso");
            }
            catch (Exception e)
            {
                return new Response<Cadeira?>(null, 500, "Não foi possível buscar a cadeira");
            }
        }

        async Task<Response<Cadeira?>> ICadeiraHandler.UpdateAsysc(UpdateCadeiraRequest request)
        {
            try
            {
                var cadeira = await context
                    .Cadeiras
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (cadeira is null)
                    return new Response<Cadeira?>(null, 404, "Cadeira não encontrada");

                cadeira.Descricao = request.Descricao;
                cadeira.Numero = request.Numero;
                cadeira.Ativo = request.Ativo;

                context.Cadeiras.Update(cadeira);
                await context.SaveChangesAsync();

                return new Response<Cadeira?>(cadeira, 200, "Cadeira atualizada com sucesso");
            }
            catch (Exception e)
            {
                return new Response<Cadeira?>(null, 500, "Não foi possível alterar a cadeira");
            }
        }
    }
}
