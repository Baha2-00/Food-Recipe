using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Recipe_Core.Migrations
{
    /// <inheritdoc />
    public partial class migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IngredientName",
                table: "Dishs",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Dishs",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "preparingStepsDescription",
                table: "Dishs",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientName",
                table: "Dishs");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Dishs");

            migrationBuilder.DropColumn(
                name: "preparingStepsDescription",
                table: "Dishs");
        }
    }
}
