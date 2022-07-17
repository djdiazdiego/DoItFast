﻿// <auto-generated />
using System;
using DoItFast.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoItFast.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DbContextWrite))]
    partial class DbContextWriteModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("DoItFast")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoItFast.Domain.Models.GatewayAggregate.Gateway", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("SerialNumber");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ReadableName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id")
                        .HasName("SerialNumber");

                    b.ToTable("Gateway", "DoItFast");
                });

            modelBuilder.Entity("DoItFast.Domain.Models.GatewayAggregate.PeripheralDevice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("GatewayId")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PeripheralDeviceStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("GatewayId");

                    b.HasIndex("PeripheralDeviceStatusId");

                    b.ToTable("PeripheralDevice", "DoItFast");
                });

            modelBuilder.Entity("DoItFast.Domain.Models.GatewayAggregate.PeripheralDeviceStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("PeripheralDeviceStatus", "DoItFast");
                });

            modelBuilder.Entity("DoItFast.Domain.Models.GatewayAggregate.PeripheralDevice", b =>
                {
                    b.HasOne("DoItFast.Domain.Models.GatewayAggregate.Gateway", "Gateway")
                        .WithMany("PeripheralDevices")
                        .HasForeignKey("GatewayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoItFast.Domain.Models.GatewayAggregate.PeripheralDeviceStatus", "PeripheralDeviceStatus")
                        .WithMany()
                        .HasForeignKey("PeripheralDeviceStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gateway");

                    b.Navigation("PeripheralDeviceStatus");
                });

            modelBuilder.Entity("DoItFast.Domain.Models.GatewayAggregate.Gateway", b =>
                {
                    b.Navigation("PeripheralDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
