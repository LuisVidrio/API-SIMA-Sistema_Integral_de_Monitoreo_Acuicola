﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApi.Entities.IOT_Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IOT_ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("Parameter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IOT_ModuleId");

                    b.ToTable("IOT_Devices");
                });

            modelBuilder.Entity("WebApi.Entities.IOT_Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PondId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PondId");

                    b.ToTable("IOT_Modules");
                });

            modelBuilder.Entity("WebApi.Entities.IOT_Value", b =>
                {
                    b.Property<int>("IOT_DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(3)");

                    b.HasKey("IOT_DeviceId", "created_at");

                    b.ToTable("IOT_Values");
                });

            modelBuilder.Entity("WebApi.Entities.Pond", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Altitude")
                        .HasColumnType("int");

                    b.Property<int>("Longitud")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ponds");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApi.Entities.IOT_Device", b =>
                {
                    b.HasOne("WebApi.Entities.IOT_Module", "IOT_Module")
                        .WithMany("IOT_Devices")
                        .HasForeignKey("IOT_ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IOT_Module");
                });

            modelBuilder.Entity("WebApi.Entities.IOT_Module", b =>
                {
                    b.HasOne("WebApi.Entities.Pond", "Pond")
                        .WithMany("IOT_Modules")
                        .HasForeignKey("PondId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pond");
                });

            modelBuilder.Entity("WebApi.Entities.IOT_Value", b =>
                {
                    b.HasOne("WebApi.Entities.IOT_Device", "IOT_Device")
                        .WithMany("IOT_Values")
                        .HasForeignKey("IOT_DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IOT_Device");
                });

            modelBuilder.Entity("WebApi.Entities.IOT_Device", b =>
                {
                    b.Navigation("IOT_Values");
                });

            modelBuilder.Entity("WebApi.Entities.IOT_Module", b =>
                {
                    b.Navigation("IOT_Devices");
                });

            modelBuilder.Entity("WebApi.Entities.Pond", b =>
                {
                    b.Navigation("IOT_Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
