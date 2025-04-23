using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hairmony_api.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_clientes_clienteid",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_colaboradores_colaboradorid",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_salao_salaoid",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_servicos_servicoid",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_clientes_salao_salaoid",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_colaboradores_salao_salaoid",
                table: "colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_servicos_salao_salaoid",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "salao_id",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "salao_id",
                table: "colaboradores");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "servicos",
                newName: "salaoId");

            migrationBuilder.RenameIndex(
                name: "IX_servicos_salaoid",
                table: "servicos",
                newName: "IX_servicos_salaoId");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "colaboradores",
                newName: "salaoId");

            migrationBuilder.RenameIndex(
                name: "IX_colaboradores_salaoid",
                table: "colaboradores",
                newName: "IX_colaboradores_salaoId");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "clientes",
                newName: "salaoId");

            migrationBuilder.RenameIndex(
                name: "IX_clientes_salaoid",
                table: "clientes",
                newName: "IX_clientes_salaoId");

            migrationBuilder.RenameColumn(
                name: "servicoid",
                table: "agendamentos",
                newName: "servicoId");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "agendamentos",
                newName: "salaoId");

            migrationBuilder.RenameColumn(
                name: "colaboradorid",
                table: "agendamentos",
                newName: "colaboradorId");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "agendamentos",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_servicoid",
                table: "agendamentos",
                newName: "IX_agendamentos_servicoId");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_salaoid",
                table: "agendamentos",
                newName: "IX_agendamentos_salaoId");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_colaboradorid",
                table: "agendamentos",
                newName: "IX_agendamentos_colaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_clienteid",
                table: "agendamentos",
                newName: "IX_agendamentos_clienteId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "salaoId",
                table: "servicos",
                newName: "salaoid");

            migrationBuilder.RenameIndex(
                name: "IX_servicos_salaoId",
                table: "servicos",
                newName: "IX_servicos_salaoid");

            migrationBuilder.RenameColumn(
                name: "salaoId",
                table: "colaboradores",
                newName: "salaoid");

            migrationBuilder.RenameIndex(
                name: "IX_colaboradores_salaoId",
                table: "colaboradores",
                newName: "IX_colaboradores_salaoid");

            migrationBuilder.RenameColumn(
                name: "salaoId",
                table: "clientes",
                newName: "salaoid");

            migrationBuilder.RenameIndex(
                name: "IX_clientes_salaoId",
                table: "clientes",
                newName: "IX_clientes_salaoid");

            migrationBuilder.RenameColumn(
                name: "servicoId",
                table: "agendamentos",
                newName: "servicoid");

            migrationBuilder.RenameColumn(
                name: "salaoId",
                table: "agendamentos",
                newName: "salaoid");

            migrationBuilder.RenameColumn(
                name: "colaboradorId",
                table: "agendamentos",
                newName: "colaboradorid");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "agendamentos",
                newName: "clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_servicoId",
                table: "agendamentos",
                newName: "IX_agendamentos_servicoid");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_salaoId",
                table: "agendamentos",
                newName: "IX_agendamentos_salaoid");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_colaboradorId",
                table: "agendamentos",
                newName: "IX_agendamentos_colaboradorid");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_clienteId",
                table: "agendamentos",
                newName: "IX_agendamentos_clienteid");

            migrationBuilder.AddColumn<Guid>(
                name: "salao_id",
                table: "servicos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "salao_id",
                table: "colaboradores",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_clientes_clienteid",
                table: "agendamentos",
                column: "clienteid",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_colaboradores_colaboradorid",
                table: "agendamentos",
                column: "colaboradorid",
                principalTable: "colaboradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_salao_salaoid",
                table: "agendamentos",
                column: "salaoid",
                principalTable: "salao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_servicos_servicoid",
                table: "agendamentos",
                column: "servicoid",
                principalTable: "servicos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_salao_salaoid",
                table: "clientes",
                column: "salaoid",
                principalTable: "salao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_colaboradores_salao_salaoid",
                table: "colaboradores",
                column: "salaoid",
                principalTable: "salao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_servicos_salao_salaoid",
                table: "servicos",
                column: "salaoid",
                principalTable: "salao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
