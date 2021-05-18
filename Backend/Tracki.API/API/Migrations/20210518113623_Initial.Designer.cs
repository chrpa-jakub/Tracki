﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TrackiBackEnd.Model;

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210518113623_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TrackiBackEnd.Model.AccountType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("text");

                    b.HasKey("TypeId");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ArtistLocation")
                        .HasColumnType("text");

                    b.Property<string>("ArtistName")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ArtistId");

                    b.HasIndex("UserId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.HasKey("PhotoId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.Release", b =>
                {
                    b.Property<int>("ReleaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AlbumName")
                        .HasColumnType("text");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("integer");

                    b.Property<int?>("ReleaseTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("integer");

                    b.HasKey("ReleaseId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ReleaseTypeId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.ReleaseType", b =>
                {
                    b.Property<int>("ReleaseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ReleaseTypeName")
                        .HasColumnType("text");

                    b.HasKey("ReleaseTypeId");

                    b.ToTable("ReleaseTypes");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ReleaseTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("SongLocation")
                        .HasColumnType("text");

                    b.Property<string>("SongName")
                        .HasColumnType("text");

                    b.HasKey("SongId");

                    b.HasIndex("ReleaseTypeId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AccountTypeTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("AccountTypeTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.Artist", b =>
                {
                    b.HasOne("TrackiBackEnd.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.Release", b =>
                {
                    b.HasOne("TrackiBackEnd.Model.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("TrackiBackEnd.Model.ReleaseType", "ReleaseType")
                        .WithMany()
                        .HasForeignKey("ReleaseTypeId");

                    b.Navigation("Artist");

                    b.Navigation("ReleaseType");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.Song", b =>
                {
                    b.HasOne("TrackiBackEnd.Model.ReleaseType", "ReleaseType")
                        .WithMany()
                        .HasForeignKey("ReleaseTypeId");

                    b.Navigation("ReleaseType");
                });

            modelBuilder.Entity("TrackiBackEnd.Model.User", b =>
                {
                    b.HasOne("TrackiBackEnd.Model.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeTypeId");

                    b.Navigation("AccountType");
                });
#pragma warning restore 612, 618
        }
    }
}
