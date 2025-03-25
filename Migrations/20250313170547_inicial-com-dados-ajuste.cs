using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlunosAPI.Migrations
{
    /// <inheritdoc />
    public partial class inicialcomdadosajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("159c9541-be12-489f-aee9-a0596838d5be"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("bd0d1a6a-fa4c-40ab-9239-c2be4ca90053"));

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Idade", "Nome" },
                values: new object[,]
                {
                    { new Guid("231c5fdf-8be4-4ce3-8378-5138f3a7d3f5"), "mariapenha@yahoo.com", 23, "Maria da Penha" },
                    { new Guid("6215bf5c-20f0-4ce0-9d4f-211003ae9324"), "manuelbueno@yahoo.com", 22, "Manuel Bueno" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("231c5fdf-8be4-4ce3-8378-5138f3a7d3f5"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("6215bf5c-20f0-4ce0-9d4f-211003ae9324"));

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Idade", "Nome" },
                values: new object[,]
                {
                    { new Guid("159c9541-be12-489f-aee9-a0596838d5be"), "mariapenha@yahoo.com", 23, "Maria da Penha" },
                    { new Guid("bd0d1a6a-fa4c-40ab-9239-c2be4ca90053"), "manuelbueno@yahoo.com", 22, "Manuel Bueno" }
                });
        }
    }
}
