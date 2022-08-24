using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftActivities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USERS__95F48440ECC75208", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "SCHEDULE",
                columns: table => new
                {
                    ID_SCHEDULE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SCHEDULE__AD4642E42D6CD594", x => x.ID_SCHEDULE);
                    table.ForeignKey(
                        name: "FK__SCHEDULE__ID_USE__38996AB5",
                        column: x => x.ID_USER,
                        principalTable: "USERS",
                        principalColumn: "ID_USER");
                });

            migrationBuilder.CreateTable(
                name: "DATE",
                columns: table => new
                {
                    ID_DATE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE_S = table.Column<DateTime>(type: "datetime", nullable: false),
                    HOUR = table.Column<int>(type: "int", nullable: false),
                    ID_SCHEDULE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DATE__524C172F09899D28", x => x.ID_DATE);
                    table.ForeignKey(
                        name: "FK__DATE__ID_SCHEDUL__3B75D760",
                        column: x => x.ID_SCHEDULE,
                        principalTable: "SCHEDULE",
                        principalColumn: "ID_SCHEDULE");
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID_USER", "PASSWORD", "USER_NAME" },
                values: new object[] { 1, "1234", "Fraiden" });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID_USER", "PASSWORD", "USER_NAME" },
                values: new object[] { 2, "1234", "Chirs" });

            migrationBuilder.CreateIndex(
                name: "IX_DATE_ID_SCHEDULE",
                table: "DATE",
                column: "ID_SCHEDULE");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULE_ID_USER",
                table: "SCHEDULE",
                column: "ID_USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DATE");

            migrationBuilder.DropTable(
                name: "SCHEDULE");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
