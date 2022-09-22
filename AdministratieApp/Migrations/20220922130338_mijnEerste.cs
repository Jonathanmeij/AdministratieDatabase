using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministratieApp.Migrations
{
    public partial class mijnEerste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Gebruikers_Id",
                        column: x => x.Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attracties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    ReserveringId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attracties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BegeleiderId = table.Column<int>(type: "INTEGER", nullable: true),
                    FavorietId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasten_Attracties_FavorietId",
                        column: x => x.FavorietId,
                        principalTable: "Attracties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasten_Gasten_BegeleiderId",
                        column: x => x.BegeleiderId,
                        principalTable: "Gasten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasten_Gebruikers_Id",
                        column: x => x.Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Probleem = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeBereik_Begin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeBereik_Eind = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AttractieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Attracties_AttractieId",
                        column: x => x.AttractieId,
                        principalTable: "Attracties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    LaatstBezochteURL = table.Column<string>(type: "TEXT", nullable: true),
                    Coordinate_X = table.Column<int>(type: "INTEGER", nullable: false),
                    Coordinate_Y = table.Column<int>(type: "INTEGER", nullable: false),
                    GastId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastInfos_Gasten_GastId",
                        column: x => x.GastId,
                        principalTable: "Gasten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTimeBereik_Begin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeBereik_Eind = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GastId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Gasten_GastId",
                        column: x => x.GastId,
                        principalTable: "Gasten",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoud",
                columns: table => new
                {
                    CoordinatorOnderhoudId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoordinatorenId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoud", x => new { x.CoordinatorOnderhoudId, x.CoordinatorenId });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud_Medewerkers_CoordinatorenId",
                        column: x => x.CoordinatorenId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud_Onderhoud_CoordinatorOnderhoudId",
                        column: x => x.CoordinatorOnderhoudId,
                        principalTable: "Onderhoud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoud1",
                columns: table => new
                {
                    UitvoerderOnderhoudId = table.Column<int>(type: "INTEGER", nullable: false),
                    UitvoerdersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoud1", x => new { x.UitvoerderOnderhoudId, x.UitvoerdersId });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud1_Medewerkers_UitvoerdersId",
                        column: x => x.UitvoerdersId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud1_Onderhoud_UitvoerderOnderhoudId",
                        column: x => x.UitvoerderOnderhoudId,
                        principalTable: "Onderhoud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attracties_ReserveringId",
                table: "Attracties",
                column: "ReserveringId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_BegeleiderId",
                table: "Gasten",
                column: "BegeleiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_FavorietId",
                table: "Gasten",
                column: "FavorietId");

            migrationBuilder.CreateIndex(
                name: "IX_GastInfos_GastId",
                table: "GastInfos",
                column: "GastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderhoud_CoordinatorenId",
                table: "MedewerkerOnderhoud",
                column: "CoordinatorenId");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderhoud1_UitvoerdersId",
                table: "MedewerkerOnderhoud1",
                column: "UitvoerdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_AttractieId",
                table: "Onderhoud",
                column: "AttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_GastId",
                table: "Reserveringen",
                column: "GastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attracties_Reserveringen_ReserveringId",
                table: "Attracties",
                column: "ReserveringId",
                principalTable: "Reserveringen",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attracties_Reserveringen_ReserveringId",
                table: "Attracties");

            migrationBuilder.DropTable(
                name: "GastInfos");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderhoud");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderhoud1");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Gasten");

            migrationBuilder.DropTable(
                name: "Attracties");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
