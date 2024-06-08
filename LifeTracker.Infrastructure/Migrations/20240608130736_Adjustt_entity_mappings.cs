using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adjustt_entity_mappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEntityUserEntity",
                schema: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupEntityUserEntity",
                schema: "Users",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntityUserEntity", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupEntityUserEntity_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalSchema: "Users",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEntityUserEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupEntityUserEntity_UsersId",
                schema: "Users",
                table: "GroupEntityUserEntity",
                column: "UsersId");
        }
    }
}
