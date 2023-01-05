﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoccerGame.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "TeamId");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Color", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 1, "EGY", "ALZamalek" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 0, "EGY", "Alahly" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Age", "Foot", "Name", "Number", "Position", "TeamId" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 20, 0, "Hussein El Shahat", 11, 2, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb51a"), 30, 2, "Mohamed Apo Treka", 22, 2, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 26, 0, "Mohamed Awad", 1, 0, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb51a"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "Id");
        }
    }
}
