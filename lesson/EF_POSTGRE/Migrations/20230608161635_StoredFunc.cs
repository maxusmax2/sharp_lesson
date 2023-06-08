using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_POSTGRE.Migrations
{
    /// <inheritdoc />
    public partial class StoredFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp1 = @"CREATE FUNCTION GetLoginForIp(
                        UnderIpAddres1 character varying(15),
                        PageNum integer,
                        RowOnPage integer
                    )
                    RETURNS TABLE(Id integer, Date timestamp, IpAddress character varying(15), DeviceSettings text, UserId integer) AS $$
                    BEGIN
                        RETURN QUERY 
                        SELECT Id, Date, IpAddress, DeviceSettings, UserId 
                        FROM LOGINS
                        WHERE IpAddress LIKE (UnderIpAddres1||'.%')
                        ORDER BY Id
                        OFFSET PageNum ROWS
                        FETCH NEXT RowOnPage ROWS ONLY;
                    END
                    $$ LANGUAGE plpgsql;";

            var sp2 = @"CREATE FUNCTION SessionsUser(
                      InputUserId integer,
                      PageNum integer,
                      RowOnPage integer
                    )
                    RETURNS TABLE (Id integer, Date timestamp, IpAddress character varying(15), DeviceSettings text, UserId integer)
                    AS $$
                    BEGIN
                      RETURN QUERY 
                      SELECT Id, Date, IpAddress, DeviceSettings, UserId 
                      FROM LOGINS 
                      WHERE UserId = $1 
                      ORDER BY Date 
                      OFFSET $2 ROWS
                      FETCH NEXT $3 ROWS ONLY;
                   END
                    $$ LANGUAGE plpgsql;";
            migrationBuilder.Sql(sp1);
            migrationBuilder.Sql(sp2);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
