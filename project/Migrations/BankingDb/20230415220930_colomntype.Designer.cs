﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.Repositories.BankSystem.Util;

#nullable disable

namespace project.Migrations.BankingDb
{
    [DbContext(typeof(BankingDbContext))]
    [Migration("20230415220930_colomntype")]
    partial class colomntype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.MasterAccount", b =>
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

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.MasterTransactions", b =>
                {
                    b.HasOne("project.Repositories.BankSystem.BankSystemModels.MasterAccount", "MasterAccount")
                        .WithMany("MasterTransactions")
                        .HasForeignKey("MasterAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterAccount");
                });

            modelBuilder.Entity("project.Repositories.BankSystem.BankSystemModels.MasterAccount", b =>
                {
                    b.Navigation("MasterTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
