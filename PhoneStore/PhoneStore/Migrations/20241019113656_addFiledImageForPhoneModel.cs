using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore.Migrations
{
    /// <inheritdoc />
    public partial class addFiledImageForPhoneModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Phones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Phones");
        }
    }
}
