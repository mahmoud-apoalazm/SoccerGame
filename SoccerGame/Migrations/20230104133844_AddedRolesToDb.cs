using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoccerGame.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c6ca06d0-6a5f-42fc-837c-6d693c2d14ca", "cc9545f1-5b07-4a68-8211-5b50d3eae359", "Manager", "MANAGER" },
                    { "f60cbc71-39dc-4beb-a9b7-91129222d937", "267e8f09-5435-48df-90db-e2a3f4a69a05", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6ca06d0-6a5f-42fc-837c-6d693c2d14ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f60cbc71-39dc-4beb-a9b7-91129222d937");
        }
    }
}
