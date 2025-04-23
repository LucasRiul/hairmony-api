using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hairmony_api.Migrations
{
    /// <inheritdoc />
    public partial class remapeandomodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_clientes_clienteId",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_colaboradores_colaboradorId",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_salao_salaoId",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_servicos_servicoId",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_clientes_salao_salaoId",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_colaboradores_salao_salaoId",
                table: "colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_servicos_salao_salaoId",
                table: "servicos");

            migrationBuilder.DropIndex(
                name: "IX_servicos_salaoId",
                table: "servicos");

            migrationBuilder.DropIndex(
                name: "IX_colaboradores_salaoId",
                table: "colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_clientes_salaoId",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "IX_agendamentos_clienteId",
                table: "agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_agendamentos_colaboradorId",
                table: "agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_agendamentos_salaoId",
                table: "agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_agendamentos_servicoId",
                table: "agendamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_servicos_salaoId",
                table: "servicos",
                column: "salaoId");

            migrationBuilder.CreateIndex(
                name: "IX_colaboradores_salaoId",
                table: "colaboradores",
                column: "salaoId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_salaoId",
                table: "clientes",
                column: "salaoId");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_clienteId",
                table: "agendamentos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_colaboradorId",
                table: "agendamentos",
                column: "colaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_salaoId",
                table: "agendamentos",
                column: "salaoId");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_servicoId",
                table: "agendamentos",
                column: "servicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_clientes_clienteId",
                table: "agendamentos",
                column: "clienteId",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_colaboradores_colaboradorId",
                table: "agendamentos",
                column: "colaboradorId",
                principalTable: "colaboradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_salao_salaoId",
                table: "agendamentos",
                column: "salaoId",
                principalTable: "salao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_servicos_servicoId",
                table: "agendamentos",
                column: "servicoId",
                principalTable: "servicos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_salao_salaoId",
                table: "clientes",
                column: "salaoId",
                principalTable: "salao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_colaboradores_salao_salaoId",
                table: "colaboradores",
                column: "salaoId",
                principalTable: "salao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_servicos_salao_salaoId",
                table: "servicos",
                column: "salaoId",
                principalTable: "salao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
