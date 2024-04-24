using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeafCast.API.Migrations
{
    /// <inheritdoc />
    public partial class PredictedPriceToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Predictions",
                newName: "PredictedPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualPrice",
                table: "Predictions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualPrice",
                table: "Predictions");

            migrationBuilder.RenameColumn(
                name: "PredictedPrice",
                table: "Predictions",
                newName: "Price");
        }
    }
}
