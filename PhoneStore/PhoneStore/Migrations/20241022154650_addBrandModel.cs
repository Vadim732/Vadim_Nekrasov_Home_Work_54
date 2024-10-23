using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore.Migrations
{
    /// <inheritdoc />
    public partial class addBrandModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Phones",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DateFoundation = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_BrandId",
                table: "Phones",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Brands_BrandId",
                table: "Phones",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Brands_BrandId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Phones_BrandId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Phones");
        }
    }
}
