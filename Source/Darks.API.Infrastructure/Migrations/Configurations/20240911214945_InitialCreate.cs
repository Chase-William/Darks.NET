using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Darks.API.Infrastructure.Migrations.Configurations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Red = table.Column<int>(type: "int", nullable: false),
                    Green = table.Column<int>(type: "int", nullable: false),
                    Blue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainMenuScreenConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainMenuScreenConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryScreenConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSelfInventroyOpenPixel_ColorId = table.Column<int>(type: "int", nullable: false),
                    IsOtherInventroyOpenPixel_ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryScreenConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryScreenConfigs_Color_IsOtherInventroyOpenPixel_ColorId",
                        column: x => x.IsOtherInventroyOpenPixel_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryScreenConfigs_Color_IsSelfInventroyOpenPixel_ColorId",
                        column: x => x.IsSelfInventroyOpenPixel_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParasaurAlarmScreenConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlarmColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParasaurAlarmScreenConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParasaurAlarmScreenConfigs_Color_AlarmColorId",
                        column: x => x.AlarmColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespawnScreenConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectBedPixel_ColorId = table.Column<int>(type: "int", nullable: false),
                    IsFastTravelScreenOpenPixel_ColorId = table.Column<int>(type: "int", nullable: false),
                    IsDeathScreenOpenPixel_ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespawnScreenConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespawnScreenConfigs_Color_IsDeathScreenOpenPixel_ColorId",
                        column: x => x.IsDeathScreenOpenPixel_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespawnScreenConfigs_Color_IsFastTravelScreenOpenPixel_ColorId",
                        column: x => x.IsFastTravelScreenOpenPixel_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespawnScreenConfigs_Color_SelectBedPixel_ColorId",
                        column: x => x.SelectBedPixel_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TribeLogScreenConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsTribeLogOpenPixel_ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TribeLogScreenConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TribeLogScreenConfigs_Color_IsTribeLogOpenPixel_ColorId",
                        column: x => x.IsTribeLogOpenPixel_ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScreenConfigs_IsOtherInventroyOpenPixel_ColorId",
                table: "InventoryScreenConfigs",
                column: "IsOtherInventroyOpenPixel_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScreenConfigs_IsSelfInventroyOpenPixel_ColorId",
                table: "InventoryScreenConfigs",
                column: "IsSelfInventroyOpenPixel_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ParasaurAlarmScreenConfigs_AlarmColorId",
                table: "ParasaurAlarmScreenConfigs",
                column: "AlarmColorId");

            migrationBuilder.CreateIndex(
                name: "IX_RespawnScreenConfigs_IsDeathScreenOpenPixel_ColorId",
                table: "RespawnScreenConfigs",
                column: "IsDeathScreenOpenPixel_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_RespawnScreenConfigs_IsFastTravelScreenOpenPixel_ColorId",
                table: "RespawnScreenConfigs",
                column: "IsFastTravelScreenOpenPixel_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_RespawnScreenConfigs_SelectBedPixel_ColorId",
                table: "RespawnScreenConfigs",
                column: "SelectBedPixel_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_TribeLogScreenConfigs_IsTribeLogOpenPixel_ColorId",
                table: "TribeLogScreenConfigs",
                column: "IsTribeLogOpenPixel_ColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryScreenConfigs");

            migrationBuilder.DropTable(
                name: "MainMenuScreenConfigs");

            migrationBuilder.DropTable(
                name: "ParasaurAlarmScreenConfigs");

            migrationBuilder.DropTable(
                name: "Resolutions");

            migrationBuilder.DropTable(
                name: "RespawnScreenConfigs");

            migrationBuilder.DropTable(
                name: "TribeLogScreenConfigs");

            migrationBuilder.DropTable(
                name: "Color");
        }
    }
}
