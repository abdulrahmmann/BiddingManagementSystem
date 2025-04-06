using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EligibilityCriteria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderDocument",
                table: "TenderDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidDocument",
                table: "BidDocument");

            migrationBuilder.RenameColumn(
                name: "DocumentPath",
                table: "TenderDocument",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "DocumentName",
                table: "TenderDocument",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DocumentPath",
                table: "BidDocument",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "DocumentName",
                table: "BidDocument",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "TenderDocument",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TenderDocument",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddColumn<int>(
                name: "TenderDocumentId",
                table: "TenderDocument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EligibilityCriteria_FinancialStabilityRequirement",
                table: "Tender",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EligibilityCriteria_IndustryCompliance",
                table: "Tender",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EligibilityCriteria_MinimumExperienceYears",
                table: "Tender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EligibilityCriteria_RequiresBusinessLicense",
                table: "Tender",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "BidDocument",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BidDocument",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddColumn<int>(
                name: "BidDocumentId",
                table: "BidDocument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderDocument",
                table: "TenderDocument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidDocument",
                table: "BidDocument",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TenderDocument_TenderDocumentId",
                table: "TenderDocument",
                column: "TenderDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderDocument_TenderId",
                table: "TenderDocument",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BidDocument_BidDocumentId",
                table: "BidDocument",
                column: "BidDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BidDocument_BidId",
                table: "BidDocument",
                column: "BidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Document",
                table: "BidDocument",
                column: "BidDocumentId",
                principalTable: "Bid",
                principalColumn: "BidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tender_Document",
                table: "TenderDocument",
                column: "TenderDocumentId",
                principalTable: "Tender",
                principalColumn: "TenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Document",
                table: "BidDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Tender_Document",
                table: "TenderDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderDocument",
                table: "TenderDocument");

            migrationBuilder.DropIndex(
                name: "IX_TenderDocument_TenderDocumentId",
                table: "TenderDocument");

            migrationBuilder.DropIndex(
                name: "IX_TenderDocument_TenderId",
                table: "TenderDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidDocument",
                table: "BidDocument");

            migrationBuilder.DropIndex(
                name: "IX_BidDocument_BidDocumentId",
                table: "BidDocument");

            migrationBuilder.DropIndex(
                name: "IX_BidDocument_BidId",
                table: "BidDocument");

            migrationBuilder.DropColumn(
                name: "TenderDocumentId",
                table: "TenderDocument");

            migrationBuilder.DropColumn(
                name: "EligibilityCriteria_FinancialStabilityRequirement",
                table: "Tender");

            migrationBuilder.DropColumn(
                name: "EligibilityCriteria_IndustryCompliance",
                table: "Tender");

            migrationBuilder.DropColumn(
                name: "EligibilityCriteria_MinimumExperienceYears",
                table: "Tender");

            migrationBuilder.DropColumn(
                name: "EligibilityCriteria_RequiresBusinessLicense",
                table: "Tender");

            migrationBuilder.DropColumn(
                name: "BidDocumentId",
                table: "BidDocument");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TenderDocument",
                newName: "DocumentName");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "TenderDocument",
                newName: "DocumentPath");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BidDocument",
                newName: "DocumentName");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "BidDocument",
                newName: "DocumentPath");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentName",
                table: "TenderDocument",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentPath",
                table: "TenderDocument",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentName",
                table: "BidDocument",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentPath",
                table: "BidDocument",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderDocument",
                table: "TenderDocument",
                columns: new[] { "TenderId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidDocument",
                table: "BidDocument",
                columns: new[] { "BidId", "Id" });

            migrationBuilder.CreateTable(
                name: "EligibilityCriteria",
                columns: table => new
                {
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialStabilityRequirement = table.Column<bool>(type: "bit", nullable: false),
                    IndustryCompliance = table.Column<bool>(type: "bit", nullable: false),
                    MinimumExperienceYears = table.Column<int>(type: "int", nullable: false),
                    RequiresBusinessLicense = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibilityCriteria", x => new { x.TenderId, x.Id });
                    table.ForeignKey(
                        name: "FK_EligibilityCriteria_Tender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tender",
                        principalColumn: "TenderId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
