using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebGame.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "leather helmet");

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "leather armor");

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "leather legs");

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "leather boots");

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "Id", "Defense", "Description", "ItemType", "Name", "Value" },
                values: new object[,]
                {
                    { 5, 100, "helmet ", "HELMET", "golden helmet", 100 },
                    { 6, 100, "armor ", "ARMOR", "magic plate armor", 100 },
                    { 7, 100, "legi ", "LEGS", "dragon scale legs", 100 },
                    { 8, 100, "bootsy ", "BOOTS", "golden boots", 100 }
                });

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "slaby");

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "silny");

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "Id", "Attack", "AttackSpeed", "CashReward", "Defense", "ExpReward", "HealthPoint", "Name" },
                values: new object[] { 3, 1, 1, 100, 1, 100, 1, "duzo exp" });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                column: "RewardExp",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "AttackSpeed", "Value" },
                values: new object[] { 20, 20, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "helmet");

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "armor");

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "legs");

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "boots");

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "enem1");

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "e2");

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                column: "RewardExp",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "AttackSpeed", "Value" },
                values: new object[] { 2, 2, 2 });
        }
    }
}
