using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGame.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class PostUptade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Conversations",
                newName: "ToId");

            migrationBuilder.AddColumn<int>(
                name: "FromId",
                table: "Conversations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Conversations");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Conversations",
                newName: "PlayerId");
        }
    }
}
