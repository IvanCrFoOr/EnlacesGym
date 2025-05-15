using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initbdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPayment",
                table: "SubscriptionUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "SubscriptionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CatInventorySuplements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSuplement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuantity = table.Column<int>(type: "int", nullable: false),
                    PricePublic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatInventorySuplements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayAperture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountAperture = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAperture = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayAperture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayClose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmountDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateClose = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayClose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventorySold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CatInventorySuplementsId = table.Column<int>(type: "int", nullable: false),
                    DateSell = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceSell = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventorySold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventorySold_CatInventorySuplements_CatInventorySuplementsId",
                        column: x => x.CatInventorySuplementsId,
                        principalTable: "CatInventorySuplements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InventorySold_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySold_CatInventorySuplementsId",
                table: "InventorySold",
                column: "CatInventorySuplementsId");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySold_UsuarioId",
                table: "InventorySold",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayAperture");

            migrationBuilder.DropTable(
                name: "DayClose");

            migrationBuilder.DropTable(
                name: "InventorySold");

            migrationBuilder.DropTable(
                name: "CatInventorySuplements");

            migrationBuilder.DropColumn(
                name: "IsPayment",
                table: "SubscriptionUsers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "SubscriptionTypes");
        }
    }
}
