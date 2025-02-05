﻿// <auto-generated />
using System;
using CreditDataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreditDataLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CreditEntityLayer.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExperienceMonths")
                        .HasColumnType("int");

                    b.Property<int?>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MonthlyIncome")
                        .HasColumnType("real");

                    b.Property<string>("PIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CreditEntityLayer.Entities.Guarantor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExperienceMonths")
                        .HasColumnType("int");

                    b.Property<int?>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MonthlyIncome")
                        .HasColumnType("real");

                    b.Property<string>("PIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationshipToApplicant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guarantors");
                });

            modelBuilder.Entity("CreditEntityLayer.Entities.LoanDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<float>("InterestRate")
                        .HasColumnType("real");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("LoanStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Principal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PurposeOfLoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonForDeclining")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TermInMonths")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("LoanDetails");
                });

            modelBuilder.Entity("CreditEntityLayer.Entities.LoanGuarantor", b =>
                {
                    b.Property<int?>("GuarantorId")
                        .HasColumnType("int");

                    b.Property<int>("LoanDetailId")
                        .HasColumnType("int");

                    b.HasKey("GuarantorId", "LoanDetailId");

                    b.HasIndex("LoanDetailId");

                    b.ToTable("LoanGuarantor");
                });

            modelBuilder.Entity("CreditEntityLayer.Entities.LoanDetail", b =>
                {
                    b.HasOne("CreditEntityLayer.Entities.Customer", "Customer")
                        .WithMany("LoanDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CreditEntityLayer.Entities.LoanGuarantor", b =>
                {
                    b.HasOne("CreditEntityLayer.Entities.Guarantor", "Guarantor")
                        .WithMany("Loans")
                        .HasForeignKey("GuarantorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CreditEntityLayer.Entities.LoanDetail", "LoanDetail")
                        .WithMany("Guarantors")
                        .HasForeignKey("LoanDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guarantor");

                    b.Navigation("LoanDetail");
                });

            modelBuilder.Entity("CreditEntityLayer.Entities.Customer", b =>
                {
                    b.Navigation("LoanDetails");
                });

            modelBuilder.Entity("CreditEntityLayer.Entities.Guarantor", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("CreditEntityLayer.Entities.LoanDetail", b =>
                {
                    b.Navigation("Guarantors");
                });
#pragma warning restore 612, 618
        }
    }
}
