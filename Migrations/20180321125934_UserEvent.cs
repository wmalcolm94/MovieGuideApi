using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MovieGuideApi.Migrations
{
    public partial class UserEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Event_Eventid",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Eventid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Eventid",
                table: "User");

            migrationBuilder.CreateTable(
                name: "UserEvent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eventId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvent", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserEvent_Event_eventId",
                        column: x => x.eventId,
                        principalTable: "Event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvent_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_eventId",
                table: "UserEvent",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_userId",
                table: "UserEvent",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvent");

            migrationBuilder.AddColumn<int>(
                name: "Eventid",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Eventid",
                table: "User",
                column: "Eventid");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Event_Eventid",
                table: "User",
                column: "Eventid",
                principalTable: "Event",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
