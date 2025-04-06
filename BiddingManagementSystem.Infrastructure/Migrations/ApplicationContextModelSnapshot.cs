﻿// <auto-generated />
using System;
using BiddingManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BidId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BidderId")
                        .HasColumnType("int");

                    b.Property<int?>("BidderId1")
                        .HasColumnType("int");

                    b.Property<string>("FinancialProposal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmittedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("TechnicalProposal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenderId")
                        .HasColumnType("int");

                    b.Property<int?>("TenderId1")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalBidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("BidderId");

                    b.HasIndex("BidderId1");

                    b.HasIndex("TenderId");

                    b.HasIndex("TenderId1");

                    b.HasIndex("UserId");

                    b.ToTable("Bid", (string)null);
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.BidItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BidItemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BidId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("ItemDescription");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("ItemName");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BidId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("BidItem", (string)null);
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Bidder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BidderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenderId");

                    b.ToTable("Bidder", (string)null);
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EvaluationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BidId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EvaluationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.PrimitiveCollection<string>("Scores")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalScore")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BidId");

                    b.HasIndex("TotalScore");

                    b.ToTable("Evaluation", (string)null);
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TenderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ClosingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Deadline")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("TenderDescription");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<int>("Industry")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("IssuedBy");

                    b.Property<int>("ReferenceNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("TenderTitle");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("Title");

                    b.ToTable("Tender", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Bid", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Entities.AppUser", null)
                        .WithMany("SubmittedBids")
                        .HasForeignKey("AppUserId");

                    b.HasOne("BiddingManagementSystem.Domain.Entities.Bidder", "Bidder")
                        .WithMany()
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Bid_Bidder");

                    b.HasOne("BiddingManagementSystem.Domain.Entities.Bidder", null)
                        .WithMany("Bids")
                        .HasForeignKey("BidderId1");

                    b.HasOne("BiddingManagementSystem.Domain.Entities.Tender", "Tender")
                        .WithMany()
                        .HasForeignKey("TenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Bid_Tender");

                    b.HasOne("BiddingManagementSystem.Domain.Entities.Tender", null)
                        .WithMany("Bids")
                        .HasForeignKey("TenderId1");

                    b.HasOne("BiddingManagementSystem.Domain.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Bid_User");

                    b.OwnsMany("BiddingManagementSystem.Domain.ValueObjects.BidDocument", "Documents", b1 =>
                        {
                            b1.Property<int>("BidId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("FilePath")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("DocumentPath");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)")
                                .HasColumnName("DocumentName");

                            b1.HasKey("BidId", "Id");

                            b1.ToTable("BidDocument");

                            b1.WithOwner()
                                .HasForeignKey("BidId");
                        });

                    b.Navigation("Bidder");

                    b.Navigation("Documents");

                    b.Navigation("Tender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.BidItem", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Entities.Bid", "Bid")
                        .WithMany("Items")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_BidItem_Bid");

                    b.Navigation("Bid");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Bidder", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Entities.Tender", "Tender")
                        .WithMany("Bidders")
                        .HasForeignKey("TenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Bidder_Tender");

                    b.Navigation("Tender");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Evaluation", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Entities.Bid", "Bid")
                        .WithMany("Evaluations")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Evaluations_Bid");

                    b.OwnsMany("BiddingManagementSystem.Domain.ValueObjects.EvaluationCriteria", "EvaluationCriterias", b1 =>
                        {
                            b1.Property<int>("EvaluationId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("CriterionName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Weight")
                                .HasColumnType("int");

                            b1.HasKey("EvaluationId", "Id");

                            b1.ToTable("EvaluationCriteria");

                            b1.WithOwner()
                                .HasForeignKey("EvaluationId");
                        });

                    b.Navigation("Bid");

                    b.Navigation("EvaluationCriterias");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Tender", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Entities.AppUser", null)
                        .WithMany("CreatedTenders")
                        .HasForeignKey("AppUserId");

                    b.HasOne("BiddingManagementSystem.Domain.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Tender_User");

                    b.OwnsOne("BiddingManagementSystem.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("TenderId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)");

                            b1.HasKey("TenderId");

                            b1.ToTable("Tender");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });

                    b.OwnsMany("BiddingManagementSystem.Domain.ValueObjects.EligibilityCriteria", "EligibilityCriteria", b1 =>
                        {
                            b1.Property<int>("TenderId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<bool>("FinancialStabilityRequirement")
                                .HasColumnType("bit");

                            b1.Property<bool>("IndustryCompliance")
                                .HasColumnType("bit");

                            b1.Property<int>("MinimumExperienceYears")
                                .HasColumnType("int");

                            b1.Property<bool>("RequiresBusinessLicense")
                                .HasColumnType("bit");

                            b1.HasKey("TenderId", "Id");

                            b1.ToTable("EligibilityCriteria");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });

                    b.OwnsOne("BiddingManagementSystem.Domain.ValueObjects.Money", "BudgetRange", b1 =>
                        {
                            b1.Property<int>("TenderId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TenderId");

                            b1.ToTable("Tender");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });

                    b.OwnsOne("BiddingManagementSystem.Domain.ValueObjects.PaymentTerms", "PaymentTerms", b1 =>
                        {
                            b1.Property<int>("TenderId")
                                .HasColumnType("int");

                            b1.Property<decimal>("AdvancePercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("FinalApprovalPercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("MilestonePercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("PaymentMethod")
                                .HasColumnType("int");

                            b1.Property<string>("PenaltyOfDelays")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TenderId");

                            b1.ToTable("Tender");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });

                    b.OwnsMany("BiddingManagementSystem.Domain.ValueObjects.TenderDocument", "Documents", b1 =>
                        {
                            b1.Property<int>("TenderId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("FilePath")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("DocumentPath");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("nvarchar(16)")
                                .HasColumnName("DocumentName");

                            b1.HasKey("TenderId", "Id");

                            b1.ToTable("TenderDocument");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("BudgetRange")
                        .IsRequired();

                    b.Navigation("Documents");

                    b.Navigation("EligibilityCriteria");

                    b.Navigation("PaymentTerms")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiddingManagementSystem.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BiddingManagementSystem.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("CreatedTenders");

                    b.Navigation("SubmittedBids");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Bid", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Bidder", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("BiddingManagementSystem.Domain.Entities.Tender", b =>
                {
                    b.Navigation("Bidders");

                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
