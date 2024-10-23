using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore.Migrations
{
    /// <inheritdoc />
    public partial class addNewBrandModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Brands_BrandId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_BrandId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Phones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Phones",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
    }
}
