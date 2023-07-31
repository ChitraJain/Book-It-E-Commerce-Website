using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShoppingProject_1.DataAccess.Migrations
{
    public partial class AddStoreP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"CREATE PROCEDURE GetCoverTypes
                                          AS
	                         SELECT*from coverTypes");
            migrationBuilder.Sql(@"CREATE PROCEDURE GetCoverType
	                                    @Id int
                                           AS
	                          SELECT*from coverTypes where Id=@Id");
            migrationBuilder.Sql(@"CREATE PROCEDURE CreateCoverType
	                                @Name varchar(50)
                                           AS
	                         Insert coverTypes values(@Name)");
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateCoverType
                                        @Id int,
	                                 @Name varchar(50)
                                            AS
	                         Update coverTypes set Name=@Name where Id=@Id");
            migrationBuilder.Sql(@"CREATE PROCEDURE DeleteCoverType
                                      @Id int
                                         AS
	                          delete coverTypes where Id=@Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
