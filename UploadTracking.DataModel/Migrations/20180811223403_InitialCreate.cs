using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UploadTracking.DataModel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    PasswordHash = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    IdToken = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    FamilyName = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    LoginTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "StoreIntegration",
                columns: table => new
                {
                    StoreIntegrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    StoreName = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    StoreId = table.Column<string>(unicode: false, nullable: true),
                    Token = table.Column<string>(unicode: false, nullable: true),
                    PlatformTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreIntegration", x => x.StoreIntegrationId);
                    table.ForeignKey(
                        name: "FK_StoreIntegration_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreIntegration_UserId",
                table: "StoreIntegration",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreIntegration");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
