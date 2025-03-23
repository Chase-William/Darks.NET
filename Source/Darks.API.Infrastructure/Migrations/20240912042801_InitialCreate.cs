using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Darks.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenericKeyMachineSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UseKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericKeyMachineSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdleMachineSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdleMachineSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMachineSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToggleSelfInventoryKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToggleOtherInventoryKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMachineSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovementMachineSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveForwardKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveBackwardKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveLeftKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveRightKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementMachineSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessMachineSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortcutUrlFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessMachineSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TribeLogMachineSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToggleTribeLogKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TribeLogMachineSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrateJob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateChannelId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrateJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrateJob_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SapJob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateChannelId = table.Column<int>(type: "int", nullable: false),
                    BedNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SapJob_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscordBotToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hwid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenericKeyMachineSettingsId = table.Column<int>(type: "int", nullable: false),
                    IdleMachineSettingsId = table.Column<int>(type: "int", nullable: false),
                    InventoryMachineSettingsId = table.Column<int>(type: "int", nullable: false),
                    MovementMachineSettingsId = table.Column<int>(type: "int", nullable: false),
                    ProcessMachineSettingsId = table.Column<int>(type: "int", nullable: false),
                    TribeLogMachineSettingsId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machine_GenericKeyMachineSettings_GenericKeyMachineSettingsId",
                        column: x => x.GenericKeyMachineSettingsId,
                        principalTable: "GenericKeyMachineSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Machine_IdleMachineSettings_IdleMachineSettingsId",
                        column: x => x.IdleMachineSettingsId,
                        principalTable: "IdleMachineSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_InventoryMachineSettings_InventoryMachineSettingsId",
                        column: x => x.InventoryMachineSettingsId,
                        principalTable: "InventoryMachineSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_MovementMachineSettings_MovementMachineSettingsId",
                        column: x => x.MovementMachineSettingsId,
                        principalTable: "MovementMachineSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_ProcessMachineSettings_ProcessMachineSettingsId",
                        column: x => x.ProcessMachineSettingsId,
                        principalTable: "ProcessMachineSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_TribeLogMachineSettings_TribeLogMachineSettingsId",
                        column: x => x.TribeLogMachineSettingsId,
                        principalTable: "TribeLogMachineSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Crate",
                columns: table => new
                {
                    CrateJobId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDoubleHarvestable = table.Column<bool>(type: "bit", nullable: false),
                    WaitUntilDeath = table.Column<bool>(type: "bit", nullable: false),
                    LoadDelay = table.Column<int>(type: "int", nullable: false),
                    BedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GetCrateInventoryInfo_Direction = table.Column<int>(type: "int", nullable: false),
                    GetCrateInventoryInfo_InitialPivotDuration = table.Column<int>(type: "int", nullable: false),
                    GetCrateInventoryInfo_PivotDuration = table.Column<int>(type: "int", nullable: false),
                    GetCrateInventoryInfo_MaxPivotStepCount = table.Column<int>(type: "int", nullable: false),
                    GetDepositInventoryInfo_Direction = table.Column<int>(type: "int", nullable: false),
                    GetDepositInventoryInfo_InitialPivotDuration = table.Column<int>(type: "int", nullable: false),
                    GetDepositInventoryInfo_PivotDuration = table.Column<int>(type: "int", nullable: false),
                    GetDepositInventoryInfo_MaxPivotStepCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crate", x => new { x.CrateJobId, x.Id });
                    table.ForeignKey(
                        name: "FK_Crate_CrateJob_CrateJobId",
                        column: x => x.CrateJobId,
                        principalTable: "CrateJob",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrateJob_GroupId",
                table: "CrateJob",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_GenericKeyMachineSettingsId",
                table: "Machine",
                column: "GenericKeyMachineSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_GroupId",
                table: "Machine",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_IdleMachineSettingsId",
                table: "Machine",
                column: "IdleMachineSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_InventoryMachineSettingsId",
                table: "Machine",
                column: "InventoryMachineSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_MovementMachineSettingsId",
                table: "Machine",
                column: "MovementMachineSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_ProcessMachineSettingsId",
                table: "Machine",
                column: "ProcessMachineSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_TribeLogMachineSettingsId",
                table: "Machine",
                column: "TribeLogMachineSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_UserId",
                table: "Machine",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SapJob_GroupId",
                table: "SapJob",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crate");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "SapJob");

            migrationBuilder.DropTable(
                name: "CrateJob");

            migrationBuilder.DropTable(
                name: "GenericKeyMachineSettings");

            migrationBuilder.DropTable(
                name: "IdleMachineSettings");

            migrationBuilder.DropTable(
                name: "InventoryMachineSettings");

            migrationBuilder.DropTable(
                name: "MovementMachineSettings");

            migrationBuilder.DropTable(
                name: "ProcessMachineSettings");

            migrationBuilder.DropTable(
                name: "TribeLogMachineSettings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
