using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoReleaseApi.Migrations
{
    public partial class spgetporelease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetPORelease]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from PORelease 
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
