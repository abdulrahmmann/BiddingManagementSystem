using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tender",
                columns: table => new
                {
                    TenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    TenderTitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TenderDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IssuedBy = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ClosingDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Industry = table.Column<int>(type: "int", nullable: false),
                    BudgetRange_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BudgetRange_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PaymentTerms_AdvancePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerms_MilestonePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerms_FinalApprovalPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerms_PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentTerms_PenaltyOfDelays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tender", x => x.TenderId);
                    table.ForeignKey(
                        name: "FK_Tender_User",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Tender_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Bidder",
                columns: table => new
                {
                    BidderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidder", x => x.BidderId);
                    table.ForeignKey(
                        name: "FK_Bidder_Tender",
                        column: x => x.TenderId,
                        principalTable: "Tender",
                        principalColumn: "TenderId");
                });

            migrationBuilder.CreateTable(
                name: "EligibilityCriteria",
                columns: table => new
                {
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequiresBusinessLicense = table.Column<bool>(type: "bit", nullable: false),
                    MinimumExperienceYears = table.Column<int>(type: "int", nullable: false),
                    FinancialStabilityRequirement = table.Column<bool>(type: "bit", nullable: false),
                    IndustryCompliance = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TenderDocument",
                columns: table => new
                {
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DocumentPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderDocument", x => new { x.TenderId, x.Id });
                    table.ForeignKey(
                        name: "FK_TenderDocument_Tender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tender",
                        principalColumn: "TenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    BidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicalProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BidderId = table.Column<int>(type: "int", nullable: false),
                    BidderId1 = table.Column<int>(type: "int", nullable: true),
                    TenderId1 = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.BidId);
                    table.ForeignKey(
                        name: "FK_Bid_Bidder",
                        column: x => x.BidderId,
                        principalTable: "Bidder",
                        principalColumn: "BidderId");
                    table.ForeignKey(
                        name: "FK_Bid_Bidder_BidderId1",
                        column: x => x.BidderId1,
                        principalTable: "Bidder",
                        principalColumn: "BidderId");
                    table.ForeignKey(
                        name: "FK_Bid_Tender",
                        column: x => x.TenderId,
                        principalTable: "Tender",
                        principalColumn: "TenderId");
                    table.ForeignKey(
                        name: "FK_Bid_Tender_TenderId1",
                        column: x => x.TenderId1,
                        principalTable: "Tender",
                        principalColumn: "TenderId");
                    table.ForeignKey(
                        name: "FK_Bid_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Bid_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "BidDocument",
                columns: table => new
                {
                    BidId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DocumentPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDocument", x => new { x.BidId, x.Id });
                    table.ForeignKey(
                        name: "FK_BidDocument_Bid_BidId",
                        column: x => x.BidId,
                        principalTable: "Bid",
                        principalColumn: "BidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidItem",
                columns: table => new
                {
                    BidItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidItem", x => x.BidItemId);
                    table.ForeignKey(
                        name: "FK_BidItem_Bid",
                        column: x => x.BidId,
                        principalTable: "Bid",
                        principalColumn: "BidId");
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Scores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    BidId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_Evaluations_Bid",
                        column: x => x.BidId,
                        principalTable: "Bid",
                        principalColumn: "BidId");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriteria",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriterionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriteria", x => new { x.EvaluationId, x.Id });
                    table.ForeignKey(
                        name: "FK_EvaluationCriteria_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluation",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bid_BidderId",
                table: "Bid",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_BidderId1",
                table: "Bid",
                column: "BidderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_TenderId",
                table: "Bid",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_TenderId1",
                table: "Bid",
                column: "TenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_UserId",
                table: "Bid",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_UserId1",
                table: "Bid",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bidder_TenderId",
                table: "Bidder",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BidItem_BidId",
                table: "BidItem",
                column: "BidId");

            migrationBuilder.CreateIndex(
                name: "IX_BidItem_ItemName",
                table: "BidItem",
                column: "ItemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_BidId",
                table: "Evaluation",
                column: "BidId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_TotalScore",
                table: "Evaluation",
                column: "TotalScore");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_CreatedById",
                table: "Tender",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_TenderTitle",
                table: "Tender",
                column: "TenderTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_UserId",
                table: "Tender",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDocument");

            migrationBuilder.DropTable(
                name: "BidItem");

            migrationBuilder.DropTable(
                name: "EligibilityCriteria");

            migrationBuilder.DropTable(
                name: "EvaluationCriteria");

            migrationBuilder.DropTable(
                name: "TenderDocument");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Bidder");

            migrationBuilder.DropTable(
                name: "Tender");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
