﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitConverterAppAPI.Entities;

#nullable disable

namespace UnitConverterAppAPI.Migrations
{
    [DbContext(typeof(UnitConverterDbContext))]
    [Migration("20220201151640_AddNewTableConversionResult")]
    partial class AddNewTableConversionResult
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UnitConverterAppAPI.Entities.Conversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConversionResultId")
                        .HasColumnType("int");

                    b.Property<decimal>("ConvertedValue")
                        .HasPrecision(38, 19)
                        .HasColumnType("decimal(38,19)");

                    b.Property<DateTime>("DateOfConversion")
                        .HasColumnType("datetime2");

                    b.Property<int>("OriginalUnitId")
                        .HasColumnType("int");

                    b.Property<int>("TargetUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConversionResultId")
                        .IsUnique();

                    b.HasIndex("OriginalUnitId");

                    b.HasIndex("TargetUnitId");

                    b.ToTable("Conversions");
                });

            modelBuilder.Entity("UnitConverterAppAPI.Entities.ConversionResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("FinalValue")
                        .HasPrecision(38, 19)
                        .HasColumnType("decimal(38,19)");

                    b.HasKey("Id");

                    b.ToTable("ConversionResults");
                });

            modelBuilder.Entity("UnitConverterAppAPI.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Factor")
                        .HasPrecision(38, 19)
                        .HasColumnType("decimal(38,19)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("UnitConverterAppAPI.Entities.Conversion", b =>
                {
                    b.HasOne("UnitConverterAppAPI.Entities.ConversionResult", "ConversionResult")
                        .WithOne("Conversion")
                        .HasForeignKey("UnitConverterAppAPI.Entities.Conversion", "ConversionResultId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UnitConverterAppAPI.Entities.Unit", "OriginalUnit")
                        .WithMany()
                        .HasForeignKey("OriginalUnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UnitConverterAppAPI.Entities.Unit", "TargetUnit")
                        .WithMany()
                        .HasForeignKey("TargetUnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ConversionResult");

                    b.Navigation("OriginalUnit");

                    b.Navigation("TargetUnit");
                });

            modelBuilder.Entity("UnitConverterAppAPI.Entities.ConversionResult", b =>
                {
                    b.Navigation("Conversion")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
