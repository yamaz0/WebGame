﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGame.Migrations
{
    /// <inheritdoc />
    public partial class AddJobToPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndJobTime",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndJobTime",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Players");
        }
    }
}
