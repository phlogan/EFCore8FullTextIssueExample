using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore8FullTextIssueExample.Migrations
{
    /// <inheritdoc />
    public partial class CreateFullTextIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT CATALOG FTE_Catalog;",
                suppressTransaction: true);

            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON Products(Name) KEY INDEX PK_Products ON FTE_Catalog;",
                suppressTransaction: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
