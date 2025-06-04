using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne2.Cinema.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class MovieCategorySeed : Migration
    {
        protected void InsertData(MigrationBuilder migrationBuilder, string name)
        {
            migrationBuilder.InsertData("MovieCategories", schema: "Cinema", columns: new[]
                {"Name", "CreatedOn", "ModifiedOn", "CreatedByUserId", "ModifiedByUserId"},
                values: new object[] { name, "2025-06-01", "2025-05-01", Guid.NewGuid(), Guid.NewGuid()});
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            InsertData(migrationBuilder, "Horror");
            InsertData(migrationBuilder, "Komedia");
            InsertData(migrationBuilder, "Obyczajowy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
