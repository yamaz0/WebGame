using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGame.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackSpeed",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "HealthPoint",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 100,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Attack",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attack", "HealthPoint" },
                values: new object[] { 1, 100 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "HealthPoint" },
                values: new object[] { 1, 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HealthPoint",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Attack",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AttackSpeed",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attack", "AttackSpeed", "HealthPoint" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "AttackSpeed", "HealthPoint" },
                values: new object[] { 0, 0, 0 });
        }
    }
}
