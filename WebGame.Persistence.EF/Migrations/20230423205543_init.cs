using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebGame.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemType = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HealthPoint = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpReward = table.Column<int>(type: "INTEGER", nullable: false),
                    CashReward = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    RewardExp = table.Column<int>(type: "INTEGER", nullable: false),
                    RewardCash = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    RewardExp = table.Column<int>(type: "INTEGER", nullable: false),
                    RewardCash = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1),
                    Exp = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Cash = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    SkillPoints = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Strenght = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 10),
                    Dexterity = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 10),
                    Endurance = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 10),
                    HealthPoint = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 100),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1),
                    HelmetId = table.Column<int>(type: "INTEGER", nullable: true),
                    ArmorId = table.Column<int>(type: "INTEGER", nullable: true),
                    LegsId = table.Column<int>(type: "INTEGER", nullable: true),
                    BootsId = table.Column<int>(type: "INTEGER", nullable: true),
                    WeaponId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ActionType = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionState = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionId = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Stamina = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "saba"),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Armors_BootsId",
                        column: x => x.BootsId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Armors_HelmetId",
                        column: x => x.HelmetId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Armors_LegsId",
                        column: x => x.LegsId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "Id", "Defense", "Description", "ItemType", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, "helmet na start", 0, "leather helmet", 1 },
                    { 2, 1, "armor na start", 1, "leather armor", 1 },
                    { 3, 1, "legi na start", 2, "leather legs", 1 },
                    { 4, 1, "bootsy na start", 3, "leather boots", 1 },
                    { 5, 100, "helmet", 0, "golden helmet", 100 },
                    { 6, 100, "armor", 1, "magic plate armor", 100 },
                    { 7, 100, "legi", 2, "dragon scale legs", 100 },
                    { 8, 100, "bootsy", 3, "golden boots", 100 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adminRoleId", "Administrator", "Administrator", "ADMINISTRATOR" },
                    { "playerRoleId", "Player", "Player", "PLAYER" }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "Id", "Attack", "AttackSpeed", "CashReward", "Defense", "ExpReward", "HealthPoint", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, 1, 1, "slaby" },
                    { 2, 555, 55, 55, 55, 55, 55, "silny" },
                    { 3, 1, 1, 100, 1, 100, 1, "duzo exp" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Description", "Duration", "Name", "RewardCash", "RewardExp" },
                values: new object[,]
                {
                    { 1, "asdasd", 1, "praca1", 0, 1 },
                    { 2, "hfgghfg", 3, "praca2", 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Description", "Duration", "Name", "RewardCash", "RewardExp" },
                values: new object[,]
                {
                    { 1, "asdasd", 1, "misja1", 0, 1 },
                    { 2, "hfgghfg", 2, "misja2", 0, 20 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ActionState", "ActionType", "ArmorId", "Attack", "BootsId", "Cash", "Defense", "Dexterity", "EndTime", "Endurance", "Exp", "HealthPoint", "HelmetId", "LegsId", "Level", "Name", "SkillPoints", "Stamina", "Strenght", "UserId", "WeaponId" },
                values: new object[,]
                {
                    { 1, 0, 0, null, 1, null, 100, 0, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1000, 100, null, null, 10, "Graczek", 10, 0, 10, "user1", null },
                    { 2, 0, 0, null, 1, null, 100, 0, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1000, 100, null, null, 10, "asdasdasdas", 10, 0, 10, "user2", null }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "Attack", "AttackSpeed", "Description", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, "mieczyk na start", "mieczyk", 1 },
                    { 2, 20, 20, "mieczyk na potem", "lepszy mieczyk", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_ArmorId",
                table: "Players",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_BootsId",
                table: "Players",
                column: "BootsId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_HelmetId",
                table: "Players",
                column: "HelmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LegsId",
                table: "Players",
                column: "LegsId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_WeaponId",
                table: "Players",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
