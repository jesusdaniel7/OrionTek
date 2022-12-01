using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrionTek.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeaddresfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Address",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Cellphone",
                table: "Address",
                newName: "State");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Address",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Address",
                newName: "Cellphone");
        }
    }
}
