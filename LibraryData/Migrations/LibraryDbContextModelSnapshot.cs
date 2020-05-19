﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryDataAccess.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryData.Models.Borrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LibraryItemId")
                        .HasColumnType("int");

                    b.Property<int?>("LibrarySubscriptionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Since")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Until")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LibraryItemId");

                    b.HasIndex("LibrarySubscriptionId");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("LibraryData.Models.BorrowHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Borrowed")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibraryItemId")
                        .HasColumnType("int");

                    b.Property<int>("LibrarySubscriptionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Returned")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LibraryItemId");

                    b.HasIndex("LibrarySubscriptionId");

                    b.ToTable("BorrowHistories");
                });

            modelBuilder.Entity("LibraryData.Models.Hold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HoldPlaced")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LibraryItemId")
                        .HasColumnType("int");

                    b.Property<int?>("LibrarySubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibraryItemId");

                    b.HasIndex("LibrarySubscriptionId");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LibraryBranches");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("NrOfCopies")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StatusId");

                    b.ToTable("LibraryItems");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LibraryItem");
                });

            modelBuilder.Entity("LibraryData.Models.LibrarySubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fees")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("LibrarySubscriptions");
                });

            modelBuilder.Entity("LibraryData.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HomeLibraryBranchId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LibrarySubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeLibraryBranchId");

                    b.HasIndex("LibrarySubscriptionId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibraryData.Models.ProgramHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CloseTime")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("OpenTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("ProgramHours");
                });

            modelBuilder.Entity("LibraryData.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("LibraryData.Models.Book", b =>
                {
                    b.HasBaseType("LibraryData.Models.LibraryItem");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeweyNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("LibraryData.Models.Movie", b =>
                {
                    b.HasBaseType("LibraryData.Models.LibraryItem");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("LibraryData.Models.Borrow", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryItem", "LibraryItem")
                        .WithMany()
                        .HasForeignKey("LibraryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryData.Models.LibrarySubscription", "LibrarySubscription")
                        .WithMany("Borrows")
                        .HasForeignKey("LibrarySubscriptionId");
                });

            modelBuilder.Entity("LibraryData.Models.BorrowHistory", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryItem", "LibraryItem")
                        .WithMany()
                        .HasForeignKey("LibraryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryData.Models.LibrarySubscription", "LibrarySubscription")
                        .WithMany()
                        .HasForeignKey("LibrarySubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryData.Models.Hold", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryItem", "LibraryItem")
                        .WithMany()
                        .HasForeignKey("LibraryItemId");

                    b.HasOne("LibraryData.Models.LibrarySubscription", "LibrarySubscription")
                        .WithMany()
                        .HasForeignKey("LibrarySubscriptionId");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryItem", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "Location")
                        .WithMany("LibraryItems")
                        .HasForeignKey("LocationId");

                    b.HasOne("LibraryData.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryData.Models.Member", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "HomeLibraryBranch")
                        .WithMany("Members")
                        .HasForeignKey("HomeLibraryBranchId");

                    b.HasOne("LibraryData.Models.LibrarySubscription", "LibrarySubscription")
                        .WithMany()
                        .HasForeignKey("LibrarySubscriptionId");
                });

            modelBuilder.Entity("LibraryData.Models.ProgramHours", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");
                });
#pragma warning restore 612, 618
        }
    }
}
