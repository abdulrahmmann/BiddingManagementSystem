using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedEntities_Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    FK_Tender_User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    BudgetRange_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BudgetRange_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElgC_FinStabReq = table.Column<bool>(type: "bit", nullable: false),
                    ElgC_IndComp = table.Column<bool>(type: "bit", nullable: false),
                    ElgC_MinExpYears = table.Column<int>(type: "int", nullable: false),
                    ElgC_ReqBizLicense = table.Column<bool>(type: "bit", nullable: false),
                    PaymentTerms_AdvancePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerms_FinalApprovalPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerms_MilestonePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerms_PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentTerms_PenaltyOfDelays = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tender", x => x.TenderId);
                    table.ForeignKey(
                        name: "FK_Tender_User",
                        column: x => x.FK_Tender_User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bidder",
                columns: table => new
                {
                    PK_BidderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_Bidder_Tender_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidder", x => x.PK_BidderId);
                    table.ForeignKey(
                        name: "FK_Bidder_Tender",
                        column: x => x.FK_Bidder_Tender_Id,
                        principalTable: "Tender",
                        principalColumn: "TenderId");
                });

            migrationBuilder.CreateTable(
                name: "TenderDocuments",
                columns: table => new
                {
                    PK_TenderDocumentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_Tender_Document_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderDocuments", x => x.PK_TenderDocumentsId);
                    table.ForeignKey(
                        name: "FK_Tender_Document",
                        column: x => x.FK_Tender_Document_Id,
                        principalTable: "Tender",
                        principalColumn: "TenderId");
                });

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    PK_BidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicalProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBidAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FK_Bid_Tender_Id = table.Column<int>(type: "int", nullable: false),
                    FK_Bid_User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FK_Bid_Bidder_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.PK_BidId);
                    table.ForeignKey(
                        name: "FK_Bid_Bidder",
                        column: x => x.FK_Bid_Bidder_Id,
                        principalTable: "Bidder",
                        principalColumn: "PK_BidderId");
                    table.ForeignKey(
                        name: "FK_Bid_Tender",
                        column: x => x.FK_Bid_Tender_Id,
                        principalTable: "Tender",
                        principalColumn: "TenderId");
                    table.ForeignKey(
                        name: "FK_Bid_User",
                        column: x => x.FK_Bid_User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BidDocuments",
                columns: table => new
                {
                    PK_BidDocumentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_Bid_Document_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDocuments", x => x.PK_BidDocumentsId);
                    table.ForeignKey(
                        name: "FK_Bid_Document",
                        column: x => x.FK_Bid_Document_Id,
                        principalTable: "Bid",
                        principalColumn: "PK_BidId");
                });

            migrationBuilder.CreateTable(
                name: "BidItem",
                columns: table => new
                {
                    PK_BidItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FK_Bid_Item_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidItem", x => x.PK_BidItemId);
                    table.ForeignKey(
                        name: "FK_BidItem_Bid",
                        column: x => x.FK_Bid_Item_Id,
                        principalTable: "Bid",
                        principalColumn: "PK_BidId");
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    PK_EvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalScore = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Scores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FK_Evaluation_Bid_Id = table.Column<int>(type: "int", nullable: false),
                    Ev_Criteria_CriterionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ev_Criteria_Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.PK_EvaluationId);
                    table.ForeignKey(
                        name: "FK_Evaluations_Bid",
                        column: x => x.FK_Evaluation_Bid_Id,
                        principalTable: "Bid",
                        principalColumn: "PK_BidId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_FK_Bid_Bidder_Id",
                table: "Bid",
                column: "FK_Bid_Bidder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_FK_Bid_Tender_Id",
                table: "Bid",
                column: "FK_Bid_Tender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_FK_Bid_User_Id",
                table: "Bid",
                column: "FK_Bid_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_TotalBidAmount",
                table: "Bid",
                column: "TotalBidAmount");

            migrationBuilder.CreateIndex(
                name: "IX_Bidder_FK_Bidder_Tender_Id",
                table: "Bidder",
                column: "FK_Bidder_Tender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BidDocuments_FK_Bid_Document_Id",
                table: "BidDocuments",
                column: "FK_Bid_Document_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BidDocuments_Name",
                table: "BidDocuments",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_BidItem_FK_Bid_Item_Id",
                table: "BidItem",
                column: "FK_Bid_Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BidItem_ItemName",
                table: "BidItem",
                column: "ItemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_FK_Evaluation_Bid_Id",
                table: "Evaluation",
                column: "FK_Evaluation_Bid_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_TotalScore",
                table: "Evaluation",
                column: "TotalScore");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_FK_Tender_User_Id",
                table: "Tender",
                column: "FK_Tender_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tender_TenderTitle",
                table: "Tender",
                column: "TenderTitle");

            migrationBuilder.CreateIndex(
                name: "IX_TenderDocuments_FK_Tender_Document_Id",
                table: "TenderDocuments",
                column: "FK_Tender_Document_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TenderDocuments_Name",
                table: "TenderDocuments",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BidDocuments");

            migrationBuilder.DropTable(
                name: "BidItem");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "TenderDocuments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Bidder");

            migrationBuilder.DropTable(
                name: "Tender");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
