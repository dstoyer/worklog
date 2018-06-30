using Microsoft.EntityFrameworkCore.Migrations;

namespace Worklog.Migrations
{
    public partial class ChangeTimeSpentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TimeSpent",
                table: "Log",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeSpent",
                table: "Log",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
