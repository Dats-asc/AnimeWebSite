﻿// <auto-generated />
using System;
using AnimeWebSite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AnimeWebSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211216121727_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AnimeWebApplication.Models.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Birthday")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("AnimeWebSite.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnimeWebApplication.Models.Profile", b =>
                {
                    b.HasOne("AnimeWebSite.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("AnimeWebApplication.Models.Profile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AnimeWebSite.Models.User", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}