using Microsoft.EntityFrameworkCore.Migrations;

namespace OneLinkTest.Infrastructure.DataAccess.Migrations
{
    public static class MigrationBuilderExtensions
    {
        public static MigrationBuilder AddStoredProcedures(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[AddEmployee]
                    @EmployeeId UNIQUEIDENTIFIER
                    @Document BIGINT
                    @DocumentId INT
                    @FirstName NVARCHAR(80)
                    @LastName NVARCHAR(80)
                    @SubareaId INT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO [dbo].[Employees] (EmployeeId, Document, DocumentType, FirstName, LastName, SubareaId)
                        VALUES (@EmployeeId, @Document, @DocumentType, @FirstName, @LastName, @SubareaId)
                END");

            return migrationBuilder;
        }
    }
}
