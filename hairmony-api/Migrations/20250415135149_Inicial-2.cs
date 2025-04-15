using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hairmony_api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cliente_id",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "colaborador_id",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "salao_id",
                table: "agendamentos");

            migrationBuilder.RenameColumn(
                name: "salao_id",
                table: "clientes",
                newName: "salaoid");

            migrationBuilder.RenameColumn(
                name: "servico_id",
                table: "agendamentos",
                newName: "salaoid");

            migrationBuilder.AddColumn<Guid>(
                name: "salaoid",
                table: "servicos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "salaoid",
                table: "colaboradores",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_servicos_salaoid",
                table: "servicos",
                column: "salaoid");

            migrationBuilder.CreateIndex(
                name: "IX_colaboradores_salaoid",
                table: "colaboradores",
                column: "salaoid");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_salaoid",
                table: "clientes",
                column: "salaoid");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_salaoid",
                table: "agendamentos",
                column: "salaoid");

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_salao_salaoid",
                table: "agendamentos",
                column: "salaoid",
                principalTable: "salao",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_salao_salaoid",
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

            migrationBuilder.DropIndex(
                name: "IX_servicos_salaoid",
                table: "servicos");

            migrationBuilder.DropIndex(
                name: "IX_colaboradores_salaoid",
                table: "colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_clientes_salaoid",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "IX_agendamentos_salaoid",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "salaoid",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "salaoid",
                table: "colaboradores");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "clientes",
                newName: "salao_id");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "agendamentos",
                newName: "servico_id");

            migrationBuilder.AddColumn<Guid>(
                name: "cliente_id",
                table: "agendamentos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "colaborador_id",
                table: "agendamentos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "salao_id",
                table: "agendamentos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
