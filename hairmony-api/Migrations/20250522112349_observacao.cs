using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hairmony_api.Migrations
{
    public partial class observacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salaoId",
                table: "servicos",
                newName: "salaoid");

            migrationBuilder.RenameColumn(
                name: "salaoId",
                table: "colaboradores",
                newName: "salaoid");

            migrationBuilder.RenameColumn(
                name: "salaoId",
                table: "clientes",
                newName: "salaoid");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "servicos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "salao",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "colaboradores",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "clientes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_de",
                table: "agendamentos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "agendamentos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_ate",
                table: "agendamentos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "agendamentos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "observacao",
                table: "agendamentos");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "servicos",
                newName: "salaoId");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "colaboradores",
                newName: "salaoId");

            migrationBuilder.RenameColumn(
                name: "salaoid",
                table: "clientes",
                newName: "salaoId");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "servicos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "salao",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "colaboradores",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "clientes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_de",
                table: "agendamentos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_criacao",
                table: "agendamentos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_ate",
                table: "agendamentos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
