using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAPI.Repository.EntityFrameWork.Migrations
{
    public partial class NewsArticleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            #region CREATE TABLES

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsArticle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SourceId = table.Column<Guid>(nullable: true),
                    Author = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    UrlToImage = table.Column<string>(nullable: true),
                    PublishedAt = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },

            #endregion

            #region CONSTRAINSTS

                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsArticle_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsArticle_Source_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            #endregion

            #region INDEX

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticle_CategoryId",
                table: "NewsArticle",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticle_SourceId",
                table: "NewsArticle",
                column: "SourceId");

            #endregion
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "NewsArticle");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Source");

        }
    }
}
