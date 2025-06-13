using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rotasbackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEspecialidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeMedico = table.Column<string>(type: "TEXT", nullable: false),
                    CrmMedico = table.Column<int>(type: "INTEGER", nullable: false),
                    DataNascimentoMedico = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EspecialidadePrincipal = table.Column<string>(type: "TEXT", nullable: false),
                    CRMUf = table.Column<string>(type: "TEXT", nullable: false),
                    TelefoneProfissional = table.Column<string>(type: "TEXT", nullable: false),
                    ValorConsulta = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEspecialidade = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    IdMedico = table.Column<int>(type: "INTEGER", nullable: true),
                    NivelComplexidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    Nascimento = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentoCPF = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    IdMedico = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEspecialidade = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorConsulta = table.Column<decimal>(type: "TEXT", nullable: false),
                    MedicoId = table.Column<int>(type: "INTEGER", nullable: true),
                    EspecialidadeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pacientes_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_IdMedico",
                table: "Especialidades",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EspecialidadeId",
                table: "Pacientes",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_MedicoId",
                table: "Pacientes",
                column: "MedicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
