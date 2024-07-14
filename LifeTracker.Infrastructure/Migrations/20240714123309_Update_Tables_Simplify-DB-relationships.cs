using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Tables_SimplifyDBrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Expenses");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                schema: "Users",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                schema: "Users",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GroupEntityId",
                schema: "Users",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                schema: "Users",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                schema: "Users",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                schema: "Users",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedbyUserId",
                schema: "Users",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedbyUserId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupEntityId",
                schema: "Users",
                table: "Users",
                column: "GroupEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupEntityId",
                schema: "Users",
                table: "Users",
                column: "GroupEntityId",
                principalSchema: "Users",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupEntityId",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupEntityId",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateModified",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupEntityId",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Users",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Users",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DateModified",
                schema: "Users",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ModifiedbyUserId",
                schema: "Users",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ModifiedbyUserId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalSchema: "Users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
