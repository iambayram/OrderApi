﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _NETCHALLENGE.Data;

#nullable disable

namespace _NETCHALLENGE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231018185901_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_NETCHALLENGE.Models.Carrier", b =>
                {
                    b.Property<int>("CarrierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarrierId"));

                    b.Property<int>("CarrierConfigurationId")
                        .HasColumnType("integer");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CarrierPlusDesiCost")
                        .HasColumnType("integer");

                    b.Property<bool>("CarrierisActive")
                        .HasColumnType("boolean");

                    b.HasKey("CarrierId");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("_NETCHALLENGE.Models.CarrierConfiguration", b =>
                {
                    b.Property<int>("CarrierConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarrierConfigurationId"));

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("numeric");

                    b.Property<int>("CarrierId")
                        .HasColumnType("integer");

                    b.Property<int>("CarrierMaxDesi")
                        .HasColumnType("integer");

                    b.Property<int>("CarrierMinDesi")
                        .HasColumnType("integer");

                    b.HasKey("CarrierConfigurationId");

                    b.ToTable("CarrierConfigurations");
                });

            modelBuilder.Entity("_NETCHALLENGE.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CarrierId")
                        .HasColumnType("integer");

                    b.Property<decimal>("OrderCarierCost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderDesi")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
