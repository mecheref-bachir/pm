﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.Repositories.BankSystem.Util;

#nullable disable

namespace project.Migrations.MyBankDb
{
    [DbContext(typeof(MyBankDbContext))]
    partial class MyBankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.MasterAccounts", b =>
                {
                    b.Property<long>("CartNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CartNumber"), 1L, 1);

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<int>("CurrentValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InitialAmount")
                        .HasColumnType("int");

                    b.Property<string>("NameOnCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartNumber");

                    b.ToTable("MasterAccounts");
                });

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.MasterTransactions", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<int>("CardBalance")
                        .HasColumnType("int");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("IssuedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("MasterAccountID")
                        .HasColumnType("bigint");

                    b.Property<Guid>("TarnsactonNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TransactionStatus")
                        .HasColumnType("int");

                    b.Property<int>("TransactionValue")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("MasterAccountID");

                    b.ToTable("MasterTransactions");
                });

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.VisaAcounts", b =>
                {
                    b.Property<long>("CartNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CartNumber"), 1L, 1);

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<int>("CurrentValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InitialAmount")
                        .HasColumnType("int");

                    b.Property<string>("NameOnCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartNumber");

                    b.ToTable("VisaAccounts");
                });

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.VisaTransactions", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<int>("CardBalance")
                        .HasColumnType("int");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("IssuedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TarnsactonNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TransactionStatus")
                        .HasColumnType("int");

                    b.Property<int>("TransactionValue")
                        .HasColumnType("int");

                    b.Property<long>("VisaAccountID")
                        .HasColumnType("bigint");

                    b.HasKey("TransactionId");

                    b.HasIndex("VisaAccountID");

                    b.ToTable("VisaTransactions");
                });

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.MasterTransactions", b =>
                {
                    b.HasOne("project.Repositories.BankSystem.BankSystemModels.MasterAccounts", "MasterAccount")
                        .WithMany("MasterTransactions")
                        .HasForeignKey("MasterAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterAccount");
                });

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.VisaTransactions", b =>
                {
                    b.HasOne("project.Repositories.BankSystem.BankSystemModels.VisaAcounts", "VisaAccount")
                        .WithMany("VisaTransactions")
                        .HasForeignKey("VisaAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VisaAccount");
                });

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.MasterAccounts", b =>
                {
                    b.Navigation("MasterTransactions");
                });

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.VisaAcounts", b =>
                {
                    b.Navigation("VisaTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
