using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDSkills.Migrations
{
    /// <inheritdoc />
    public partial class addIsActiveColumnToSkillTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "skills",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "skills");
        }
    }
}
