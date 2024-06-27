using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoCadeiras.API.Migrations
{
    /// <inheritdoc />
    public partial class viewproximoagendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("create view ProximoAgendamento as "+
                                 "select  c.Id CadeiraId "+
                                 "from gestaodb.cadeiras c "+
                                 "left join (select CadeiraId, Max(Data) Data, max(HoraInicio) HoraInicio, max(HoraFim) HoraFim "+
                                 "from gestaodb.agendas "+
                                 "group by CadeiraId) a on a.CadeiraId = c.Id "+
                                 "where ativo = 1 "+
                                 "order by Data, HoraInicio, horaFim, CadeiraId " +
                                 "limit 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW ProximoAgendamento;");
        }
    }
}
