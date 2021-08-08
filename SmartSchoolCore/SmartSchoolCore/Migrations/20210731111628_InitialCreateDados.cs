using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchoolCore.Migrations
{
    public partial class InitialCreateDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2021, 7, 31, 8, 16, 27, 748, DateTimeKind.Local).AddTicks(1165), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lauro", 1, "Oliveira", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2021, 7, 31, 8, 16, 27, 751, DateTimeKind.Local).AddTicks(424), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", 2, "Soares", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2021, 7, 31, 8, 16, 27, 751, DateTimeKind.Local).AddTicks(550), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronaldo", 3, "Marconi", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2021, 7, 31, 8, 16, 27, 751, DateTimeKind.Local).AddTicks(559), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodrigo", 4, "Carvalho", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2021, 7, 31, 8, 16, 27, 751, DateTimeKind.Local).AddTicks(561), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandre", 5, "Montanha", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
