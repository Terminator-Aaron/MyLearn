using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.SQLite.Migrations
{
    public partial class AddProductReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlCopy",
                table: "Blogs",
                nullable: true);

            migrationBuilder.Sql(
                @"
                    UPDATE Blogs
                    SET UrlCopy = Url;
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlCopy",
                table: "Blogs");
        }
    }
}
